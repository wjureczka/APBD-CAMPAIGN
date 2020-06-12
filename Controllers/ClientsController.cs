using System;
using System.Linq;
using System.Threading.Tasks;
using APBD_CAMPAIGN.DAL;
using APBD_CAMPAIGN.DTO.Requests;
using APBD_CAMPAIGN.DTO.Responses;
using APBD_CAMPAIGN.Models;
using APBD_CAMPAIGN.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_CAMPAIGN.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private AdvertCampaignContext _advertCampaignContext;

        private IAuthService _authService;

        public ClientsController(AdvertCampaignContext advertCampaignContext, IAuthService authService)
        {
            _advertCampaignContext = advertCampaignContext;
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clients = await _advertCampaignContext.Client.ToListAsync();

            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = await _advertCampaignContext.Client.FindAsync(id);

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserRequest createUserRequest)
        { 
            var newClient = new Client
            {
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName,
                Email = createUserRequest.Email,
                Login = createUserRequest.Login,
                Password = createUserRequest.Password
            };

            try
            {
                await _advertCampaignContext.Client.AddAsync(newClient);
                await _advertCampaignContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return Conflict();
            }

            return CreatedAtAction("Get", new { id = newClient.IdClient }, newClient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateUserRequest updateUserRequest)
        {
            var client = await _advertCampaignContext.Client.FindAsync(updateUserRequest.IdClient);

            if(client == null)
            {
                return NotFound();
            }

            client.FirstName = updateUserRequest.FirstName;
            client.LastName = updateUserRequest.LastName;
            client.Email = updateUserRequest.Email;
            client.Login = updateUserRequest.Login;
            client.Password = updateUserRequest.Password;
            client.Phone = updateUserRequest.Phone;

            _advertCampaignContext.Client.Update(client);

            await _advertCampaignContext.SaveChangesAsync();

            return Ok(client);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _advertCampaignContext.Client.Remove(new Client { IdClient = id });

            await _advertCampaignContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> ValidateRefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            Client client;

            try
            {
                client = await _advertCampaignContext.Client
                    .Where(entity => entity.RefreshToken.Equals(refreshTokenRequest.RefreshToken))
                    .FirstAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return BadRequest();
            }

            var tokens = _authService.GenerateTokens();

            client.RefreshToken = tokens.RefreshToken;
            _advertCampaignContext.Client.Update(client);
            await _advertCampaignContext.SaveChangesAsync();

            return Ok(new RefreshTokenResponse
            {
                AccessToken = tokens.AccessToken,
                RefreshToken = client.RefreshToken
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            Client client = null;

            try
            {
                client = await _advertCampaignContext.Client
                    .Where(entity => entity.Login.Equals(loginRequest.Login) && entity.Password.Equals(loginRequest.Password))
                    .FirstAsync();

            } catch (Exception exception)
            {
                Console.WriteLine(exception);
                return BadRequest();
            }

            var tokens = _authService.GenerateTokens();

            client.RefreshToken = tokens.RefreshToken;
            _advertCampaignContext.Client.Update(client);
            await _advertCampaignContext.SaveChangesAsync();

            return Ok(new LoginResponse
            {
                AccessToken = tokens.AccessToken,
                RefreshToken = client.RefreshToken
            });
        }
    }
}
