using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_CAMPAIGN.Models
{
    public class Banner
    {
        [Key]
        public int IdAdvertisement { get; set; }

        public int Name { get; set; }

        public decimal Price { get; set; }

        public decimal Area { get; set; }

        public int IdCampaign { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
