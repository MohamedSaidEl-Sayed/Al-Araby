using Kenouz.Data;

namespace Kenouz.Models.Repositories
{
    public class PdfQuizRepo : IKenouzRepo<PdfQuiz>,IPdfQuizRepo
    {
        private readonly KenouzDbContext _context;
        public PdfQuizRepo(KenouzDbContext context)
        {
            _context = context;
        }
        public List<PdfQuiz> GetAll()
        {
            return _context.PdfQuizzes.ToList();
        }
        public PdfQuiz? Get(int id)
        {
            return _context.PdfQuizzes.Find(id);
        }
        public void Add(PdfQuiz pdfQuiz)
        {
            _context.PdfQuizzes.Add(pdfQuiz);
            _context.SaveChanges();
        }
        public void Update(PdfQuiz pdfQuiz)
        {
            _context.PdfQuizzes.Update(pdfQuiz);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            PdfQuiz? entity = Get(id);
            if (entity != null)
            {
                _context.PdfQuizzes.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<PdfQuiz> GetForUser(int userNum)
        {
            List<PdfQuiz> pdfQuizzes = _context.PdfQuizzes.Where(pq => pq.ClassYearId == userNum).ToList();
            return pdfQuizzes;
        }

       
    }
}
