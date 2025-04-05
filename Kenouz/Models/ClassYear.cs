using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kenouz.Models
{
    public class ClassYear
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string Name { get; set; } = string.Empty;
        public List<TeachingC>? TeachingCategories { get; set; }
        public List<QuizPerLessonC>? QuizPerLessonCategories { get; set; }
        public List<RateYourselfQuiz>? RateYourselfQuizzes { get; set; }
        public List<PdfQuiz>? PdfQuizzes { get; set; }
    }
}
