using Kenouz.Data;

namespace Kenouz.Models.Repositories
{
    public class ClassYearRepo : IKenouzRepo<ClassYear>, IClassYearRepo
    {
        private readonly KenouzDbContext _context;
        public ClassYearRepo(KenouzDbContext context)
        {
            _context = context;
        }
        public List<ClassYear> GetAll()
        {
            return _context.ClassYears.ToList();
        }
        public ClassYear? Get(int id)
        {
            return _context.ClassYears.Find(id);
        }
        public void Add(ClassYear classYear)
        {
            _context.ClassYears.Add(classYear);
            _context.SaveChanges();
        }
        public void Update(ClassYear classYear)
        {
            _context.ClassYears.Update(classYear);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            ClassYear? entity = Get(id);
            if (entity != null)
            {
                _context.ClassYears.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<ClassYear> GetForUser(int userNum)
        {
            throw new NotImplementedException();
        }

        public ClassYear GetByName(string name)
        {
            return (_context.ClassYears.FirstOrDefault(c => c.Name == name));
        }
    }
}
