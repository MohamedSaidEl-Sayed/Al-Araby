using Kenouz.Data;
using Microsoft.EntityFrameworkCore;

namespace Kenouz.Models.Repositories
{
    public class TeachingCULRepo:IKenouzRepo<TeachingCUL>,ITeachingCULRepo
    {
        private readonly KenouzDbContext _context;
        public TeachingCULRepo(KenouzDbContext context)
        {
            _context = context;
        }

        public void Add(TeachingCUL entity)
        {
            _context.TeachingCategoryUnitLessons.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            TeachingCUL? entity = Get(id);
            if (entity != null)
            {
                _context.TeachingCategoryUnitLessons.Remove(entity);
                _context.SaveChanges();
            }
        }

        public TeachingCUL? Get(int id)
        {
            return _context.TeachingCategoryUnitLessons.Find(id);
        }

        public List<TeachingCUL> GetAll()
        {
            return _context.TeachingCategoryUnitLessons.ToList();
        }

       

        public void Update(TeachingCUL entity)
        {
            _context.TeachingCategoryUnitLessons.Update(entity);
            _context.SaveChanges();
        }

        public List<int> GetForUser(int classYearId)
        {
            var list = _context.TeachingCategories.Where(c => c.ClassYearId == classYearId)
                        .Join(
                            _context.TeachingCategoryUnits,
                            c => c.Id,
                            cu => cu.TeachingCategoryId,
                            (c, cu) => new { UnitId = cu.Id })
                        .GroupJoin(
                            _context.TeachingCategoryUnitLessons,
                            a => a.UnitId,
                            cul => cul.TeachingCategoryUnitId,
                            (a, cul) => new { Lessons = cul, tt = 'k' })
                        .SelectMany(
                            a => a.Lessons, 
                            (a, l) => new { LessonId = l.Id }
                            );

            List<int> lessonsId = new List<int>();
            foreach(var lesson in list)
            {
                lessonsId.Add(lesson.LessonId);
            }
            return lessonsId;

            
        }
    }
}
