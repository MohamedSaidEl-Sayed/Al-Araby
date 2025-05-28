using System.ComponentModel.DataAnnotations;

namespace Kenouz.ViewModels
{
    public class AddCodeViewModel
    {
        [Required]
        [StringLength(100,ErrorMessage ="hhh hhhh hhh",MinimumLength =6)]
        public string Code { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
