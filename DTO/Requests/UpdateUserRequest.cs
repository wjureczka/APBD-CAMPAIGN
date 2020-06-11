using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace APBD_CAMPAIGN.DTO.Requests
{
    public class UpdateUserRequest
    {
        [Required]
        public int IdClient { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Login { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
