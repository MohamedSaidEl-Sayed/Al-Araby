namespace Kenouz.Models.Repositories
{
    public interface IQuizPerLessonCRepo
    {
        List<QuizPerLessonC> GetForUser(int userNum);
    }
}
