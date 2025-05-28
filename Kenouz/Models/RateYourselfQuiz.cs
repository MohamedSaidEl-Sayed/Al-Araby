using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kenouz.Models
{
    public class RateYourselfQuiz
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = String.Empty;
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Level { get; set; } = string.Empty;
        [Required]
        public int Time { get; set; }//minutes
        public int ClassYearId { get; set; }
        public ClassYear? ClassYear { get; set; }
        public List<RateYourselfQuizS>? RateYourselfQuizScripts { get; set; }
    }
}
