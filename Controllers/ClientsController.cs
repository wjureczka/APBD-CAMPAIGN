using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APBD_CAMPAIGN.DAL;
using APBD_CAMPAIGN.DTO.Requests;
using APBD_CAMPAIGN.DTO.Responses;
using APBD_CAMPAIGN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace APBD_CAMPAIGN.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private AdvertCampaignContext _advertCampaignContext;

        private IConfiguration _configuration { get; set; }

        public ClientsController(AdvertCampaignContext advertCampaign, IConfiguration configuration)
        {
            _advertCampaignContext = advertCampaign;
            _configuration = configuration;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var client = await _advertCampaignContext.Client
                .Where(entity => entity.Login.Equals(loginRequest.Login) && entity.Password.Equals(loginRequest.Password))
                .FirstAsync();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name, "client"),
                new Claim(ClaimTypes.Role, "client")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT_BEARER"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: "DODATKOWY_PROJEKT_ISSUER",
                audience: "DODATKOWY_PROJEKT_AUDIENCE",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials
            );

            var refreshToken = Guid.NewGuid();

            client.AccessToken = token.ToString();
            client.RefreshToken = refreshToken.ToString();

            this._advertCampaignContext.Client.Update(client);
            await this._advertCampaignContext.SaveChangesAsync();

            return Ok(new LoginResponse
            {
                AccessToken = client.AccessToken,
                RefreshToken = client.RefreshToken
            });
        }
    }
}
