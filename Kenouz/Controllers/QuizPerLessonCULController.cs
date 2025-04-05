using Kenouz.Models;
using Kenouz.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kenouz.Controllers
{
    [Authorize]
    public class QuizPerLessonCULController : Controller
    {
        private readonly IKenouzRepo<QuizPerLessonCUL> _quizPerLessonCULRepo;
        public QuizPerLessonCULController(IKenouzRepo<QuizPerLessonCUL> quizPerLessonCULRepo)
        {
            _quizPerLessonCULRepo = quizPerLessonCULRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(QuizPerLessonCUL model)
        {
            if (ModelState.IsValid)
            {
                _quizPerLessonCULRepo.Add(model);
            }
            return RedirectToAction("QuizPerLessonC", "Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(QuizPerLessonCUL model)
        {
            if (ModelState.IsValid)
            {
                _quizPerLessonCULRepo.Update(model);
            }
            return RedirectToAction("QuizPerLessonC", "Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            QuizPerLessonCUL quizPerLessonCUL = _quizPerLessonCULRepo.Get(id);
            if(quizPerLessonCUL is not null)
            {
                _quizPerLessonCULRepo.Delete(id);
            }
            return RedirectToAction("QuizPerLessonC", "Admin");
        }
    }
}
