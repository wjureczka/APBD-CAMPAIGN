using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_CAMPAIGN.DAL;
using APBD_CAMPAIGN.DTO.Requests;
using APBD_CAMPAIGN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_CAMPAIGN.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private AdvertCampaignContext _advertCampaignContext;

        public ClientsController(AdvertCampaignContext advertCampaign)
        {
            _advertCampaignContext = advertCampaign;
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
            var client = await _advertCampaignContext.Client.AddAsync(new Client
            {
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName,
                Email = createUserRequest.Email,
                Login = createUserRequest.Login,
                Password = createUserRequest.Password
            });


            await _advertCampaignContext.SaveChangesAsync();

            return CreatedAtAction("client", client);
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
    }
}
