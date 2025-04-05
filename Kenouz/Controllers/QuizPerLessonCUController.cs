using Kenouz.Models;
using Kenouz.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kenouz.Controllers
{
    [Authorize]
    public class QuizPerLessonCUController : Controller
    {
        private readonly IKenouzRepo<QuizPerLessonCU> _quizPerLessonCURepo;
        public QuizPerLessonCUController(IKenouzRepo<QuizPerLessonCU> quizPerLessonCURepo)
        {
            _quizPerLessonCURepo = quizPerLessonCURepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(QuizPerLessonCU model)
        {
            if (ModelState.IsValid)
            {
                _quizPerLessonCURepo.Add(model);
            }
            return RedirectToAction("QuizPerLessonC", "Admin");
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(QuizPerLessonCU model)
        {
            if (ModelState.IsValid)
            {
                _quizPerLessonCURepo.Update(model);
            }
            return RedirectToAction("QuizPerLessonC", "Admin");
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            QuizPerLessonCU quizPerLessonCU = _quizPerLessonCURepo.Get(id);
            if(quizPerLessonCU is not null)
            {
                _quizPerLessonCURepo.Delete(id);
            }
            return RedirectToAction("QuizPerLessonC", "Admin");
        }
    }
}
