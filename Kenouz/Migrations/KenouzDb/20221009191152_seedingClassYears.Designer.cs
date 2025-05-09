﻿// <auto-generated />
using Kenouz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kenouz.Migrations.KenouzDb
{
    [DbContext(typeof(KenouzDbContext))]
    [Migration("20221009191152_seedingClassYears")]
    partial class seedingClassYears
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Kenouz.Models.ClassYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("ClassYears");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "الصف الأول الثانوي"
                        },
                        new
                        {
                            Id = 2,
                            Name = "الصف الثاني الثانوي"
                        },
                        new
                        {
                            Id = 3,
                            Name = "الصف الثالث الثانوي"
                        });
                });

            modelBuilder.Entity("Kenouz.Models.PdfQuiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassYearId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ClassYearId");

                    b.ToTable("PdfQuizzes");
                });

            modelBuilder.Entity("Kenouz.Models.QuizPerLessonC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassYearId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ClassYearId");

                    b.ToTable("QuizPerLessonCategories");
                });

            modelBuilder.Entity("Kenouz.Models.QuizPerLessonCU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("QuizPerLessonCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizPerLessonCategoryId");

                    b.ToTable("QuizPerLessonCategoryUnits");
                });

            modelBuilder.Entity("Kenouz.Models.QuizPerLessonCUL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("QuizPerLessonCategoryUnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizPerLessonCategoryUnitId");

                    b.ToTable("QuizPerLessonCategoryUnitLessons");
                });

            modelBuilder.Entity("Kenouz.Models.QuizPerLessonCULQ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answer1")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Answer2")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Answer3")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Answer4")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Answer5")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Minutes")
                        .HasColumnType("int");

                    b.Property<string>("QuestionTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("QuizPerLessonCategoryUnitLessonId")
                        .HasColumnType("int");

                    b.Property<string>("RightAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Script")
                        .HasColumnType("nvarchar(4000)");

                    b.Property<int>("Seconds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizPerLessonCategoryUnitLessonId");

                    b.ToTable("QuizPerLessonCategoryUnitLessonQuestions");
                });

            modelBuilder.Entity("Kenouz.Models.RateYourselfQuiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassYearId")
                        .HasColumnType("int");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassYearId");

                    b.ToTable("RateYourselfQuizzes");
                });

            modelBuilder.Entity("Kenouz.Models.RateYourselfQuizS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RateYourselfQuizId")
                        .HasColumnType("int");

                    b.Property<string>("Script")
                        .IsRequired()
                        .HasColumnType("nvarchar(4000)");

                    b.HasKey("Id");

                    b.HasIndex("RateYourselfQuizId");

                    b.ToTable("RateYourselfQuizScripts");
                });

            modelBuilder.Entity("Kenouz.Models.RateYourselfQuizSQ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answer1")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Answer2")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Answer3")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Answer4")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Answer5")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("QuestionTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("RateYourselfQuizScriptId")
                        .HasColumnType("int");

                    b.Property<string>("RightAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("RateYourselfQuizScriptId");

                    b.ToTable("RateYourselfQuizScriptQuestions");
                });

            modelBuilder.Entity("Kenouz.Models.TeachingC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassYearId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ClassYearId");

                    b.ToTable("TeachingCategories");
                });

            modelBuilder.Entity("Kenouz.Models.TeachingCU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TeachingCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeachingCategoryId");

                    b.ToTable("TeachingCategoryUnits");
                });

            modelBuilder.Entity("Kenouz.Models.TeachingCUL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PdfLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeachingCategoryUnitId")
                        .HasColumnType("int");

                    b.Property<string>("VideoLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeachingCategoryUnitId");

                    b.ToTable("TeachingCategoryUnitLessons");
                });

            modelBuilder.Entity("Kenouz.Models.PdfQuiz", b =>
                {
                    b.HasOne("Kenouz.Models.ClassYear", "ClassYear")
                        .WithMany("PdfQuizzes")
                        .HasForeignKey("ClassYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassYear");
                });

            modelBuilder.Entity("Kenouz.Models.QuizPerLessonC", b =>
                {
                    b.HasOne("Kenouz.Models.ClassYear", "ClassYear")
                        .WithMany("QuizPerLessonCategories")
                        .HasForeignKey("ClassYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassYear");
                });

            modelBuilder.Entity("Kenouz.Models.QuizPerLessonCU", b =>
                {
                    b.HasOne("Kenouz.Models.QuizPerLessonC", "QuizPerLessonCategory")
                        .WithMany("QuizPerLessonCategoryUnits")
                        .HasForeignKey("QuizPerLessonCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuizPerLessonCategory");
                });

            modelBuilder.Entity("Kenouz.Models.QuizPerLessonCUL", b =>
                {
                    b.HasOne("Kenouz.Models.QuizPerLessonCU", "quizPerLessonCategoryUnit")
                        .WithMany("QuizPerLessonCategoryUnitLessons")
                        .HasForeignKey("QuizPerLessonCategoryUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("quizPerLessonCategoryUnit");
                });

            modelBuilder.Entity("Kenouz.Models.QuizPerLessonCULQ", b =>
                {
                    b.HasOne("Kenouz.Models.QuizPerLessonCUL", "quizPerLessonCategoryUnitLesson")
                        .WithMany("QuizPerLessonCategoryUnitLessonQuestions")
                        .HasForeignKey("QuizPerLessonCategoryUnitLessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("quizPerLessonCategoryUnitLesson");
                });

            modelBuilder.Entity("Kenouz.Models.RateYourselfQuiz", b =>
                {
                    b.HasOne("Kenouz.Models.ClassYear", "ClassYear")
                        .WithMany("RateYourselfQuizzes")
                        .HasForeignKey("ClassYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassYear");
                });

            modelBuilder.Entity("Kenouz.Models.RateYourselfQuizS", b =>
                {
                    b.HasOne("Kenouz.Models.RateYourselfQuiz", "RateYourselfQuiz")
                        .WithMany("RateYourselfQuizScripts")
                        .HasForeignKey("RateYourselfQuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RateYourselfQuiz");
                });

            modelBuilder.Entity("Kenouz.Models.RateYourselfQuizSQ", b =>
                {
                    b.HasOne("Kenouz.Models.RateYourselfQuizS", "RateYourselfQuizScript")
                        .WithMany("RateYourselfQuizScriptQuestions")
                        .HasForeignKey("RateYourselfQuizScriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RateYourselfQuizScript");
                });

            modelBuilder.Entity("Kenouz.Models.TeachingC", b =>
                {
                    b.HasOne("Kenouz.Models.ClassYear", "ClassYear")
                        .WithMany("TeachingCategories")
                        .HasForeignKey("ClassYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassYear");
                });

            modelBuilder.Entity("Kenouz.Models.TeachingCU", b =>
                {
                    b.HasOne("Kenouz.Models.TeachingC", "TeachingCategory")
                        .WithMany("TeachingCategoryUnits")
                        .HasForeignKey("TeachingCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeachingCategory");
                });

            modelBuilder.Entity("Kenouz.Models.TeachingCUL", b =>
                {
                    b.HasOne("Kenouz.Models.TeachingCU", "TeachingCategoryUnit")
                        .WithMany("TeachingCategoryUnitLessons")
                        .HasForeignKey("TeachingCategoryUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeachingCategoryUnit");
                });

            modelBuilder.Entity("Kenouz.Models.ClassYear", b =>
                {
                    b.Navigation("PdfQuizzes");

                    b.Navigation("QuizPerLessonCategories");

                    b.Navigation("RateYourselfQuizzes");

                    b.Navigation("TeachingCategories");
                });

            modelBuilder.Entity("Kenouz.Models.QuizPerLessonC", b =>
                {
                    b.Navigation("QuizPerLessonCategoryUnits");
                });

            modelBuilder.Entity("Kenouz.Models.QuizPerLessonCU", b =>
                {
                    b.Navigation("QuizPerLessonCategoryUnitLessons");
                });

            modelBuilder.Entity("Kenouz.Models.QuizPerLessonCUL", b =>
                {
                    b.Navigation("QuizPerLessonCategoryUnitLessonQuestions");
                });

            modelBuilder.Entity("Kenouz.Models.RateYourselfQuiz", b =>
                {
                    b.Navigation("RateYourselfQuizScripts");
                });

            modelBuilder.Entity("Kenouz.Models.RateYourselfQuizS", b =>
                {
                    b.Navigation("RateYourselfQuizScriptQuestions");
                });

            modelBuilder.Entity("Kenouz.Models.TeachingC", b =>
                {
                    b.Navigation("TeachingCategoryUnits");
                });

            modelBuilder.Entity("Kenouz.Models.TeachingCU", b =>
                {
                    b.Navigation("TeachingCategoryUnitLessons");
                });
#pragma warning restore 612, 618
        }
    }
}
