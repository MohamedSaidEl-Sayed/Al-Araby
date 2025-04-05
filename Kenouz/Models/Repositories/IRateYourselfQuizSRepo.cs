namespace Kenouz.Models.Repositories
{
    public interface IRateYourselfQuizSRepo
    {
        List<RateYourselfQuizS> GetForQuiz(int quizId);
    }
}
