using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_CAMPAIGN.Models
{
    public class Campaign
    {
        [Key]
        public int IdCampaign { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal PricePerSquareMeter { get; set; }

        public Client Client { get; set; }

        public Building FromIdBuilding { get; set; }

        public Building ToIdBuilding { get; set; }
    }
}
