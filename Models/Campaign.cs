using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_CAMPAIGN.Models
{
    public class Campaign
    {
        [Key]
        public int IdCampaign { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal PricePerSquareMeter { get; set; }

        public int IdClient { get; set; }

        public virtual Client Client { get; set; }

        public int FromIdBuilding { get; set; }

        public virtual Building FromBuilding { get; set; }

        public int ToIdBuilding { get; set; }

        public virtual Building ToBuilding { get; set; }
    }
}
