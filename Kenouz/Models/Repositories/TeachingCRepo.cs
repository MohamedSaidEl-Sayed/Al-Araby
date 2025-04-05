using Kenouz.Data;
using Microsoft.EntityFrameworkCore;

namespace Kenouz.Models.Repositories
{
    public class TeachingCRepo:IKenouzRepo<TeachingC>,ITeachingCRepo
    {
        private readonly KenouzDbContext _context;
        public TeachingCRepo(KenouzDbContext context)
        {
            _context = context;
        }

        public void Add(TeachingC entity)
        {
            _context.TeachingCategories.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            TeachingC? entity = Get(id);
            if (entity != null)
            {
                _context.TeachingCategories.Remove(entity);
                _context.SaveChanges();
            }
        }

        public TeachingC? Get(int id)
        {
            return _context.TeachingCategories.Find(id);
        }

        public List<TeachingC> GetAll()
        {
            return _context.TeachingCategories.ToList();
        }

      
        public void Update(TeachingC entity)
        {
            _context.TeachingCategories.Update(entity);
            _context.SaveChanges();
        }

        public List<TeachingC> GetForUser(int userNum)
        {
           
            var teachingCs = _context.TeachingCategories.Where(t => t.ClassYearId == userNum)
                            .Include(t => t.TeachingCategoryUnits)
                            .ThenInclude(tus => tus.TeachingCategoryUnitLessons)
                            .ToList();

            return teachingCs;           
           
        }

       
    }
}
