using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kenouz.Models
{
    public class TeachingCUL
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = string.Empty;
        public string? VideoLink { get; set; }
        public string? PdfLink { get; set; }
        public int TeachingCategoryUnitId { get; set; }
        public TeachingCU? TeachingCategoryUnit { get; set; }
    }
}
