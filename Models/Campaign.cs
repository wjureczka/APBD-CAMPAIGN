using System;
using System.Collections.Generic;
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
        [ForeignKey("IdClient")]
        public Client Client { get; set; }

        public int FromIdBuilding { get; set; }
        [ForeignKey("FromIdBuilding")]
        public Building FromBuilding { get; set; }

        public int ToIdBuilding { get; set; }
        [ForeignKey("ToIdBuilding")]
        public Building ToBuilding { get; set; }

        [InverseProperty("Campaign")]
        public ICollection<Banner> Banners { get; set; }
    }
}
