using System.ComponentModel.DataAnnotations;

namespace Post3_GoogleReCaptchaV2.Models
{
    public class MessageViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
