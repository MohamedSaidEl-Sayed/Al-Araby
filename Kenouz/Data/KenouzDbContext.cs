using Kenouz.Models;
using Microsoft.EntityFrameworkCore;

namespace Kenouz.Data
{
    public class KenouzDbContext : DbContext
    {
        public KenouzDbContext(DbContextOptions<KenouzDbContext> options) : base(options)
        {
        }
        public DbSet<ClassYear> ClassYears { get; set; }
        public DbSet<TeachingC> TeachingCategories { get; set; }
        public DbSet<TeachingCU> TeachingCategoryUnits { get; set; }
        public DbSet<TeachingCUL> TeachingCategoryUnitLessons { get; set; }
        public DbSet<QuizPerLessonC> QuizPerLessonCategories { get; set; }
        public DbSet<QuizPerLessonCU> QuizPerLessonCategoryUnits { get; set; }
        public DbSet<QuizPerLessonCUL> QuizPerLessonCategoryUnitLessons { get; set; }
        public DbSet<QuizPerLessonCULQ> QuizPerLessonCategoryUnitLessonQuestions { get; set; }
        public DbSet<RateYourselfQuiz> RateYourselfQuizzes { get; set; }
        public DbSet<RateYourselfQuizS> RateYourselfQuizScripts { get; set; }
        public DbSet<RateYourselfQuizSQ> RateYourselfQuizScriptQuestions { get; set; }
        public DbSet<PdfQuiz> PdfQuizzes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassYear>()
                .HasData(
                new ClassYear { Id = 1 , Name = "الصف الأول الثانوي" },
                new ClassYear { Id = 2 , Name = "الصف الثاني الثانوي" },
                new ClassYear { Id = 3 , Name = "الصف الثالث الثانوي" }
                );
        }
    }
}
