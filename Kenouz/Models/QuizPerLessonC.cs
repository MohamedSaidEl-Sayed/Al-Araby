using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kenouz.Models
{
    public class QuizPerLessonC
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; } = string.Empty;
        public int ClassYearId { get; set; }
        public ClassYear? ClassYear { get; set; }
        public List<QuizPerLessonCU>? QuizPerLessonCategoryUnits { get; set; }
    }
}
