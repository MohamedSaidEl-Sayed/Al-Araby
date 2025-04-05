using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kenouz.Data
{
    public class Logged_in_Users
    {
        [Key]
        [Column(TypeName = "nvarchar(500)")]
        public string UserID { get; set; } = string.Empty;
    }
}
