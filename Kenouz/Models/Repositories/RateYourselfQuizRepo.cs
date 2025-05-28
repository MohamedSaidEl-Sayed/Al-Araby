using Kenouz.Data;

namespace Kenouz.Models.Repositories
{
    public class RateYourselfQuizRepo:IKenouzRepo<RateYourselfQuiz>,IRateYourselfQuizRepo
    {
        private readonly KenouzDbContext _context;
        public RateYourselfQuizRepo(KenouzDbContext context)
        {
            _context = context;
        }

        public void Add(RateYourselfQuiz entity)
        {
            _context.RateYourselfQuizzes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            RateYourselfQuiz? entity = Get(id);
            if (entity != null)
            {
                _context.RateYourselfQuizzes.Remove(entity);
                _context.SaveChanges();
            }
        }

        public RateYourselfQuiz? Get(int id)
        {
            return _context.RateYourselfQuizzes.Find(id);
        }

        public List<RateYourselfQuiz> GetAll()
        {
            return _context.RateYourselfQuizzes.ToList();
        }

        public void Update(RateYourselfQuiz entity)
        {
            _context.RateYourselfQuizzes.Update(entity);
            _context.SaveChanges();
        }

        public List<RateYourselfQuiz> GetForUser(int userId)
        {
            List<RateYourselfQuiz> rateYourselfQuizzes = _context.RateYourselfQuizzes
                                                            .Where(rq => rq.ClassYearId == userId)
                                                            .ToList();
            return rateYourselfQuizzes;
        }
    }
}
