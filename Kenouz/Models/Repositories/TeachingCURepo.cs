using Kenouz.Data;

namespace Kenouz.Models.Repositories
{
    public class TeachingCURepo:IKenouzRepo<TeachingCU>
    {
        private readonly KenouzDbContext _context;
        public TeachingCURepo(KenouzDbContext context)
        {
            _context = context;
        }

        public void Add(TeachingCU entity)
        {
            _context.TeachingCategoryUnits.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            TeachingCU? entity = Get(id);
            if (entity != null)
            {
                _context.TeachingCategoryUnits.Remove(entity);
                _context.SaveChanges();
            }
        }

        public TeachingCU? Get(int id)
        {
            return _context.TeachingCategoryUnits.Find(id);
        }

        public List<TeachingCU> GetAll()
        {
            return _context.TeachingCategoryUnits.ToList();
        }

      

        public void Update(TeachingCU entity)
        {
            _context.TeachingCategoryUnits.Update(entity);
            _context.SaveChanges();
        }
    }
}
