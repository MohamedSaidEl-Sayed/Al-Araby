using System.ComponentModel.DataAnnotations.Schema;

namespace Kenouz.Models
{
    public class QuizPerLessonCUL
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = string.Empty;
        public int QuizPerLessonCategoryUnitId { get; set; }
        public QuizPerLessonCU? quizPerLessonCategoryUnit { get; set; }
        public List<QuizPerLessonCULQ>? QuizPerLessonCategoryUnitLessonQuestions { get; set; }
    }
}
