using Kenouz.Data;

namespace Kenouz.Models.Repositories
{
    public class QuizPerLessonCULQRepo:IKenouzRepo<QuizPerLessonCULQ>,IQuizPerLessonCULQRepo
    {
        private readonly KenouzDbContext _context;
        public QuizPerLessonCULQRepo(KenouzDbContext context)
        {
            _context = context;
        }
        public void Add(QuizPerLessonCULQ entity)
        {
            _context.QuizPerLessonCategoryUnitLessonQuestions.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            QuizPerLessonCULQ? entity = Get(id);
            if (entity != null)
            {
                _context.QuizPerLessonCategoryUnitLessonQuestions.Remove(entity);
                _context.SaveChanges();
            }
        }

        public QuizPerLessonCULQ? Get(int id)
        {
            return _context.QuizPerLessonCategoryUnitLessonQuestions.Find(id);
        }

        public List<QuizPerLessonCULQ> GetAll()
        {
            return _context.QuizPerLessonCategoryUnitLessonQuestions.ToList();
        }

        public List<QuizPerLessonCULQ> GetForLesson(int lessonId)
        {
            List<QuizPerLessonCULQ> quizPerLessonCULQs = _context.QuizPerLessonCategoryUnitLessonQuestions
                                                        .Where(q => q.QuizPerLessonCategoryUnitLessonId == lessonId)
                                                        .ToList();
            return quizPerLessonCULQs;
        }

        public void Update(QuizPerLessonCULQ entity)
        {
            _context.QuizPerLessonCategoryUnitLessonQuestions.Update(entity);
            _context.SaveChanges();
        }

       
    }
}
