using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kenouz.Models
{
    public class PdfQuiz
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Link { get; set; } = string.Empty;
        public int ClassYearId { get; set; }
        public ClassYear? ClassYear { get; set; }
    }
}
