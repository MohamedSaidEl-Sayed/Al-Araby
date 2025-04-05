namespace Kenouz.Models.Repositories
{
    public interface ITeachingCRepo
    {
        List<TeachingC> GetForUser(int userNum);
    }
}
