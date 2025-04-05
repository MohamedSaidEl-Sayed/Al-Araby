namespace Kenouz.Models.Repositories
{
    public interface IPdfQuizRepo
    {
        List<PdfQuiz> GetForUser(int userNum);
    }
}
