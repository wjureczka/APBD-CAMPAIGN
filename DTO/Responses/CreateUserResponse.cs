using System.ComponentModel.DataAnnotations;

namespace APBD_CAMPAIGN.DTO.Responses
{
    public class CreateUserResponse
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Login { get; set; }
    }
}