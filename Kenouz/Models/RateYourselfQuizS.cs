using System.ComponentModel.DataAnnotations.Schema;

namespace Kenouz.Models
{
    public class RateYourselfQuizS
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(4000)")]
        public string Script { get; set; } = string.Empty;
        public int RateYourselfQuizId { get; set; }
        public RateYourselfQuiz? RateYourselfQuiz { get; set; }
        public List<RateYourselfQuizSQ>? RateYourselfQuizScriptQuestions { get; set; }
    }
}
