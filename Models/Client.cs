using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_CAMPAIGN.Models
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string Login { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        public string RefreshToken { get; set; }

        [InverseProperty("Client")]
        public ICollection<Campaign> Campaigns { get; set; }
    }
}
