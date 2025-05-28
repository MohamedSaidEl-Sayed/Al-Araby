using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kenouz.Data
{
    public class DeactivatedUser
    {
        [Key]
        [Column(TypeName ="nvarchar(500)")]
        public string UserId { get; set; } = string.Empty;
    }
}
