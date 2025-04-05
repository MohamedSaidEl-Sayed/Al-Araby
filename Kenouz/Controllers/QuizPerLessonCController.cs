using Kenouz.Controllers.Helper;
using Kenouz.Models;
using Kenouz.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kenouz.Controllers
{
    [Authorize]
    public class QuizPerLessonCController : Controller
    {
        private readonly IKenouzRepo<QuizPerLessonC> _quizPerLessonCRepo;
        private readonly IQuizPerLessonCRepo _quizPerLessonCRepo1;
        private readonly CheckCode _checkCode;

        public QuizPerLessonCController(IKenouzRepo<QuizPerLessonC> quizPerLessonCRepo, IQuizPerLessonCRepo quizPerLessonCRepo1, CheckCode checkCode)
        {
            _quizPerLessonCRepo = quizPerLessonCRepo;
            _quizPerLessonCRepo1 = quizPerLessonCRepo1;
            _checkCode = checkCode;
        }

        public IActionResult Index(int classId)
        {
            bool IsAllowed = _checkCode.Check(User.Identity.Name).Result;
            if (IsAllowed)
            {
                if (User.IsInRole("User1") && classId == 1)
                {
                    ViewData["classYearId"] = classId;
                    return View(_quizPerLessonCRepo1.GetForUser(classId));
                }
                else if (User.IsInRole("User2") && classId == 2)
                {
                    ViewData["classYearId"] = classId;
                    return View(_quizPerLessonCRepo1.GetForUser(classId));
                }
                else if (User.IsInRole("User3") && classId == 3)
                {
                    ViewData["classYearId"] = classId;
                    return View(_quizPerLessonCRepo1.GetForUser(classId));
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
        public IActionResult Add(QuizPerLessonC model)
        {
            if (ModelState.IsValid)
            {
                _quizPerLessonCRepo.Add(model);
            }
            return RedirectToAction("QuizPerLessonC", "Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(QuizPerLessonC model)
        {
            if(ModelState.IsValid)
            {
                _quizPerLessonCRepo.Update(model);
            }
            return RedirectToAction("QuizPerLessonC", "Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            QuizPerLessonC quizPerLessonC = _quizPerLessonCRepo.Get(id);
            if(quizPerLessonC is not null)
            {
                _quizPerLessonCRepo.Delete(id);
            }
            return RedirectToAction("QuizPerLessonC", "Admin");
        }
    }
}
