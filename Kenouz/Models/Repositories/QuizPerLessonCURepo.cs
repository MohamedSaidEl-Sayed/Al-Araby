using Kenouz.Data;

namespace Kenouz.Models.Repositories
{
    public class QuizPerLessonCURepo:IKenouzRepo<QuizPerLessonCU>
    {
        private readonly KenouzDbContext _context;
        public QuizPerLessonCURepo(KenouzDbContext context)
        {
            _context = context;
        }
        public List<QuizPerLessonCU> GetAll()
        {
            return _context.QuizPerLessonCategoryUnits.ToList();
        }
        public QuizPerLessonCU? Get(int id)
        {
            return _context.QuizPerLessonCategoryUnits.Find(id);
        }
        public void Add(QuizPerLessonCU entity)
        {
            _context.QuizPerLessonCategoryUnits.Add(entity);
            _context.SaveChanges();
        }
        public void Update(QuizPerLessonCU entity)
        {
            _context.QuizPerLessonCategoryUnits.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            QuizPerLessonCU? entity = Get(id);
            if (entity != null)
            {
                _context.QuizPerLessonCategoryUnits.Remove(entity);
                _context.SaveChanges();
            }
        }

       
    }
}
