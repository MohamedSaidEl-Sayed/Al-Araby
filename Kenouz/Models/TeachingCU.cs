using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kenouz.Models
{
    public class TeachingCU
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = string.Empty;
        public int TeachingCategoryId { get; set; }
        public TeachingC? TeachingCategory { get; set; }
        public List<TeachingCUL>? TeachingCategoryUnitLessons { get; set; }
    }
}
