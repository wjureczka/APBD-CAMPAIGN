using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_CAMPAIGN.Models
{
    public class Building
    {
        [Key]
        public int IdBuilding { get; set; }

        [MaxLength(200)]
        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public string City { get; set; }

        public decimal Height;
    }
}
