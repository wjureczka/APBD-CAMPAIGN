using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Height;

        [InverseProperty("ToBuilding")]
        public ICollection<Campaign> ToBuildings { get; set; }
        
        [InverseProperty("FromBuilding")]
        public ICollection<Campaign> FromBuildings { get; set; }
    }
}
