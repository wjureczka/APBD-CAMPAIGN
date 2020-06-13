using System;
using System.ComponentModel.DataAnnotations;

namespace APBD_CAMPAIGN.DTO.Requests
{
  
    public class CreateCampaignRequest
    {
        [Required]
        public int IdClient { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal PricePerSquareMeter { get; set; }

        [Required]
        public int FromIdBuilding { get; set; }

        [Required]
        public int ToIdBuilding { get; set; }
    }
}
