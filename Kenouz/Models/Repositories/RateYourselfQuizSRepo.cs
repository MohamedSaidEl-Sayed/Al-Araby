using Kenouz.Data;
using Microsoft.EntityFrameworkCore;

namespace Kenouz.Models.Repositories
{
    public class RateYourselfQuizSRepo:IKenouzRepo<RateYourselfQuizS>, IRateYourselfQuizSRepo
    {
        private readonly KenouzDbContext _context;
        public RateYourselfQuizSRepo(KenouzDbContext context)
        {
            _context = context;
        }

        public void Add(RateYourselfQuizS entity)
        {
            _context.RateYourselfQuizScripts.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            RateYourselfQuizS? entity = Get(id);
            if (entity != null)
            {
                _context.RateYourselfQuizScripts.Remove(entity);
                _context.SaveChanges();
            }
        }

        public RateYourselfQuizS? Get(int id)
        {
            return _context.RateYourselfQuizScripts.Find(id);
        }

        public List<RateYourselfQuizS> GetAll()
        {
            return _context.RateYourselfQuizScripts.ToList();
        }

        
        public void Update(RateYourselfQuizS entity)
        {
            _context.RateYourselfQuizScripts.Update(entity);
            _context.SaveChanges();
        }

        public List<RateYourselfQuizS> GetForQuiz(int quizId)
        {
            List<RateYourselfQuizS> rateYourselfQuizSs = _context.RateYourselfQuizScripts
                                                        .Where(s => s.RateYourselfQuizId == quizId)
                                                        .Include(s => s.RateYourselfQuizScriptQuestions)
                                                        .ToList();
            return rateYourselfQuizSs;
        }
    }
}
