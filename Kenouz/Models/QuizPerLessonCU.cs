using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kenouz.Models
{
    public class QuizPerLessonCU
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = string.Empty;
        public int QuizPerLessonCategoryId { get; set; }
        public QuizPerLessonC? QuizPerLessonCategory { get; set; }
        public List<QuizPerLessonCUL>? QuizPerLessonCategoryUnitLessons { get; set; }
    }
}
