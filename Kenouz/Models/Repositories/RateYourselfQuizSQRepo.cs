using Kenouz.Data;

namespace Kenouz.Models.Repositories
{
    public class RateYourselfQuizSQRepo:IKenouzRepo<RateYourselfQuizSQ>
    {
        private readonly KenouzDbContext _context;
        public RateYourselfQuizSQRepo(KenouzDbContext context)
        {
            _context = context;
        }

        public void Add(RateYourselfQuizSQ entity)
        {
            _context.RateYourselfQuizScriptQuestions.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            RateYourselfQuizSQ? entity = Get(id);
            if (entity != null)
            {
                _context.RateYourselfQuizScriptQuestions.Remove(entity);
                _context.SaveChanges();
            }
        }

        public RateYourselfQuizSQ? Get(int id)
        {
            return _context.RateYourselfQuizScriptQuestions.Find(id);
        }

        public List<RateYourselfQuizSQ> GetAll()
        {
            return _context.RateYourselfQuizScriptQuestions.ToList();
        }

      
        public void Update(RateYourselfQuizSQ entity)
        {
            _context.RateYourselfQuizScriptQuestions.Update(entity);
            _context.SaveChanges();
        }
    }
}
