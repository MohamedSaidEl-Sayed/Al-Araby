namespace Kenouz.Models.Repositories
{
    public interface IQuizPerLessonCULQRepo
    {
        List<QuizPerLessonCULQ> GetForLesson(int lessonId);
    }
}
