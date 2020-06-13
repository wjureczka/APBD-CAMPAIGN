using System;
using System.Linq;
using System.Threading.Tasks;
using APBD_CAMPAIGN.DAL;
using APBD_CAMPAIGN.DTO.Requests;
using APBD_CAMPAIGN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_CAMPAIGN.Controllers
{
    [Route("api/campaigns")]
    [ApiController]
    [Authorize]
    public class CampaignController : ControllerBase
    {
        private AdvertCampaignContext _advertCampaignContext;

        public CampaignController(AdvertCampaignContext advertCampaignContext)
        {
            _advertCampaignContext = advertCampaignContext;
        }

        // GET: api/<CampaignController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var campaigns = await _advertCampaignContext.Campaign
                .AsNoTracking()
                .OrderByDescending(campaign => campaign.StartDate)
                .Select(campaign => new
                {
                    StartDate = campaign.StartDate,
                    EndDate = campaign.EndDate,
                    PricePerSquareMeter = campaign.PricePerSquareMeter,
                    Client = campaign.Client,
                    Banners = campaign.Banners
                })
                .ToListAsync();

            return Ok(campaigns);
        }

        // GET api/<CampaignController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var campaign = await _advertCampaignContext.Campaign.FindAsync(id);
            return Ok(campaign);
        }

        // POST api/<CampaignController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCampaignRequest createCampaignRequest)
        {
            Building buildingFrom;
            Building buildingTo;

            try
            {
                buildingFrom = await _advertCampaignContext.Building.FindAsync(createCampaignRequest.FromIdBuilding);
                buildingTo = await _advertCampaignContext.Building.FindAsync(createCampaignRequest.ToIdBuilding);

                if(!buildingFrom.Street.Equals(buildingTo.Street))
                {
                    return BadRequest();
                }
            } catch(Exception exception)
            {
                Console.WriteLine(exception);
                return NotFound();
            }

            return Ok();
        }

        // PUT api/<CampaignController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CampaignController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
