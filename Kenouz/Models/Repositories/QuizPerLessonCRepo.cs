using Kenouz.Data;
using Microsoft.EntityFrameworkCore;

namespace Kenouz.Models.Repositories
{
    public class QuizPerLessonCRepo:IKenouzRepo<QuizPerLessonC>,IQuizPerLessonCRepo
    {
        private readonly KenouzDbContext _context;
        public QuizPerLessonCRepo(KenouzDbContext context)
        {
            _context = context;
        }
        public List<QuizPerLessonC> GetAll()
        {
            return _context.QuizPerLessonCategories.ToList();
        }
        public QuizPerLessonC? Get(int id)
        {
            return _context.QuizPerLessonCategories.Find(id);
        }
        public void Add(QuizPerLessonC quizPerLessonC)
        {
            _context.QuizPerLessonCategories.Add(quizPerLessonC);
            _context.SaveChanges();
        }
        public void Update(QuizPerLessonC quizPerLessonC)
        {
            _context.QuizPerLessonCategories.Update(quizPerLessonC);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            QuizPerLessonC? entity = Get(id);
            if (entity != null)
            {
                _context.QuizPerLessonCategories.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<QuizPerLessonC> GetForUser(int userNum)
        {
            var quizPerLessonCs = _context.QuizPerLessonCategories.Where(t => t.ClassYearId == userNum)
                            .Include(t => t.QuizPerLessonCategoryUnits)
                            .ThenInclude(tus => tus.QuizPerLessonCategoryUnitLessons)
                            .ToList();

            return quizPerLessonCs;
        }
    }
}
