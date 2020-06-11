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
            var client = await _advertCampaignContext.Client.Where(entity => entity.IdClient.Equals(id)).FirstAsync();

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

            return CreatedAtAction("client", client);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
