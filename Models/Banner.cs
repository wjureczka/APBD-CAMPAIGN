using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace APBD_CAMPAIGN.Models
{
    public class Banner
    {
        [Key]
        public int IdAdvertisement { get; set; }

        public int Name { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Area { get; set; }

        public int IdCampaign { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
