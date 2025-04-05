using Kenouz.Models;

namespace Kenouz.ViewModels
{
    public class AdminQuizPerLessonCViewModel
    {
        public List<QuizPerLessonC>? quizPerLessonCs;
        public QuizPerLessonC? quizPerLessonC { get; set; }
        public QuizPerLessonCU? quizPerLessonCU { get; set; }
        public QuizPerLessonCUL? quizPerLessonCUL { get; set; }
    }
}
