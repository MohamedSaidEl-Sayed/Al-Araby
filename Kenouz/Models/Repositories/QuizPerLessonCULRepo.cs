using Kenouz.Data;

namespace Kenouz.Models.Repositories
{
    public class QuizPerLessonCULRepo:IKenouzRepo<QuizPerLessonCUL>,IQuizPerLessonCULRepo
    {
        private readonly KenouzDbContext _context;
        public QuizPerLessonCULRepo(KenouzDbContext context)
        {
            _context = context;
        }

        public List<QuizPerLessonCUL> GetAll()
        {
            return _context.QuizPerLessonCategoryUnitLessons.ToList();
        }
        public QuizPerLessonCUL? Get(int id)
        {
            return _context.QuizPerLessonCategoryUnitLessons.Find(id);
        }
        public void Add(QuizPerLessonCUL entity)
        {
            _context.QuizPerLessonCategoryUnitLessons.Add(entity);
            _context.SaveChanges();
        }
        public void Update(QuizPerLessonCUL entity)
        {
            _context.QuizPerLessonCategoryUnitLessons.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            QuizPerLessonCUL? entity = Get(id);
            if (entity != null)
            {
                _context.QuizPerLessonCategoryUnitLessons.Remove(entity);
                _context.SaveChanges();
            }
        }

        // to get the ids of lessons which belong to that classYearId to after that check if the user attempt to get a lesson which not belongs to his classyear
        public List<int> GetForUser(int classYearId)
        {
            var result = _context.QuizPerLessonCategories.Where(c => c.ClassYearId == classYearId)
                        .Join(
                            _context.QuizPerLessonCategoryUnits,
                            c => c.Id,
                            cu => cu.QuizPerLessonCategoryId,
                            (c, cu) => new
                            {
                                UnitId = cu.Id
                            })
                        .GroupJoin(
                            _context.QuizPerLessonCategoryUnitLessons,
                            a => a.UnitId,
                            cul => cul.QuizPerLessonCategoryUnitId,
                            (a, cul) => new
                            {
                                Lessons = cul
                            })
                        .SelectMany(
                            b => b.Lessons,
                            (b, l) => new
                            {
                                LessonId = l.Id
                            });

            List<int> lessonsIds = new List<int>();

            foreach(var l in result)
            {
                lessonsIds.Add(l.LessonId);
            }
            return lessonsIds;
        }

    }
}
