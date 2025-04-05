namespace Kenouz.Models.Repositories
{
    public interface IRateYourselfQuizRepo
    {
        List<RateYourselfQuiz> GetForUser(int userId);
    }
}
