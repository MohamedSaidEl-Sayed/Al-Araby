namespace Kenouz.Models.Repositories
{
    public interface IQuizPerLessonCULRepo
    {
        // to get the ids of lessons which belong to that classYearId to after that check if the user attempt to get a lesson which not belongs to his classyear
        List<int> GetForUser(int classYearId);
    }
}
