using System.Threading.Tasks;
using APBD_CAMPAIGN.DAL;
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
            var campaigns = await _advertCampaignContext.Campaign.ToListAsync();

            return Ok(campaigns);
        }

        // GET api/<CampaignController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CampaignController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
