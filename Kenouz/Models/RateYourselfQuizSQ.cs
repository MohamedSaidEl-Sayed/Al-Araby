using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kenouz.Models
{
    public class RateYourselfQuizSQ
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string QuestionTitle { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(1000)")]
        public string Answer1 { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(1000)")]
        public string Answer2 { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(1000)")]
        public string Answer3 { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(1000)")]
        public string? Answer4 { get; set; }
        [Column(TypeName = "nvarchar(1000)")]
        public string? Answer5 { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string RightAnswer { get; set; } = string.Empty;
        public int RateYourselfQuizScriptId { get; set; }
        public RateYourselfQuizS? RateYourselfQuizScript { get; set; }
    }
}
