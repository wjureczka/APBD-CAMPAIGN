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

        public int IdClient { get; set; }

        public virtual Client Client { get; set; }

        public int FromIdBuilding { get; set; }

        public virtual Building FromBuilding { get; set; }

        public int ToIdBuilding { get; set; }

        public virtual Building ToBuilding { get; set; }
    }
}
