using Kenouz.Controllers.Helper;
using Kenouz.Models;
using Kenouz.Models.Repositories;
using Kenouz.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kenouz.Controllers
{
    [Authorize]
    public class QuizPerLessonCULQController : Controller
    {
        private readonly IKenouzRepo<QuizPerLessonCULQ> _quizPerLessonCULQRepo;
        private readonly IQuizPerLessonCULQRepo _quizPerLessonCULQRepo1;
        private readonly IQuizPerLessonCULRepo _quizPerLessonCULRepo;
        private readonly CheckCode _checkCode;

        public QuizPerLessonCULQController(IKenouzRepo<QuizPerLessonCULQ> quizPerLessonCULQRepo, IQuizPerLessonCULQRepo quizPerLessonCULQRepo1, IQuizPerLessonCULRepo quizPerLessonCULRepo, CheckCode checkCode)
        {
            _quizPerLessonCULQRepo = quizPerLessonCULQRepo;
            _quizPerLessonCULQRepo1 = quizPerLessonCULQRepo1;
            _quizPerLessonCULRepo = quizPerLessonCULRepo;
            _checkCode = checkCode;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int lessonId, int classYearId)
        {
            bool IsAllowed = _checkCode.Check(User.Identity.Name).Result;
            if (IsAllowed)
            {
                bool IsBelongsTo(int lessonId, int yearId)
                {
                    List<int> lessonsOfClassYear = _quizPerLessonCULRepo.GetForUser(yearId);
                    return lessonsOfClassYear.Contains(lessonId);
                }
                if (User.IsInRole("User1") && classYearId == 1)
                {
                    if (IsBelongsTo(lessonId, classYearId))
                    {
                        List<QuizPerLessonCULQ> model = _quizPerLessonCULQRepo1.GetForLesson(lessonId);
                        if (model == null)
                        {
                            return NotFound();
                        }
                        return View(model);
                    }
                    return NotFound();

                }
                else if (User.IsInRole("User2") && classYearId == 2)
                {
                    if (IsBelongsTo(lessonId, classYearId))
                    {
                        List<QuizPerLessonCULQ> model = _quizPerLessonCULQRepo1.GetForLesson(lessonId);
                        if (model == null)
                        {
                            return NotFound();
                        }
                        return View(model);
                    }
                    return NotFound();
                }
                else if (User.IsInRole("User3") && classYearId == 3)
                {
                    if (IsBelongsTo(lessonId, classYearId))
                    {
                        List<QuizPerLessonCULQ> model = _quizPerLessonCULQRepo1.GetForLesson(lessonId);
                        if (model == null)
                        {
                            return NotFound();
                        }
                        return View(model);
                    }
                    return NotFound();
                }
                else
                {
                    return NotFound();
                }
            }
            return NotFound();

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(QuizPerLessonCULQ model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("QuizPerLessonCULQ", "Admin", new { id = model.QuizPerLessonCategoryUnitLessonId });
            }
            _quizPerLessonCULQRepo.Add(model);
            return RedirectToAction("QuizPerLessonCULQ", "Admin", new{id = model.QuizPerLessonCategoryUnitLessonId});
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            QuizPerLessonCULQ model = _quizPerLessonCULQRepo.Get(id);
            if(model != null)
            {
                return View(model);
            }
            return NotFound();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(QuizPerLessonCULQ model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                _quizPerLessonCULQRepo.Update(model);
                return RedirectToAction("QuizPerLessonCULQ", "Admin", new { id = model.QuizPerLessonCategoryUnitLessonId });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            QuizPerLessonCULQ model = _quizPerLessonCULQRepo.Get(id);
            if (model != null)
            {
                _quizPerLessonCULQRepo.Delete(id);
                return RedirectToAction("QuizPerLessonCULQ", "Admin", new { id = model.QuizPerLessonCategoryUnitLessonId });
            }
            return NotFound();
        }


    }
}
