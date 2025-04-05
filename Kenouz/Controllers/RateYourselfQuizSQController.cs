using Kenouz.Models;
using Kenouz.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kenouz.Controllers
{
    [Authorize]
    public class RateYourselfQuizSQController : Controller
    {
        private readonly IKenouzRepo<RateYourselfQuizSQ> _rateYourselfQuizSQRepo;
        private readonly IKenouzRepo<RateYourselfQuizS> _rateYourselfQuizSRepo;

        public RateYourselfQuizSQController(IKenouzRepo<RateYourselfQuizSQ> rateYourselfQuizSQRepo
                                            , IKenouzRepo<RateYourselfQuizS> rateYourselfQuizSRepo)
        {
            _rateYourselfQuizSQRepo = rateYourselfQuizSQRepo;
            _rateYourselfQuizSRepo = rateYourselfQuizSRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(RateYourselfQuizSQ model)
        {
            if(ModelState.IsValid && model.RateYourselfQuizScriptId != 0)
            {
                RateYourselfQuizS m = _rateYourselfQuizSRepo.Get(model.RateYourselfQuizScriptId);
                if (m is not null)
                {
                    _rateYourselfQuizSQRepo.Add(model);
                    return RedirectToAction("RateYourselfQuizS", "Admin", new { quizId = m.RateYourselfQuizId });
                }
            }
            return NotFound();

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            RateYourselfQuizSQ model = _rateYourselfQuizSQRepo.Get(id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RateYourselfQuizSQ model)
        {
            if (ModelState.IsValid)
            {
                RateYourselfQuizS m = _rateYourselfQuizSRepo.Get(model.RateYourselfQuizScriptId);
                if (m is not null)
                {
                    _rateYourselfQuizSQRepo.Update(model);
                    return RedirectToAction("RateYourselfQuizS", "Admin", new { quizId = m.RateYourselfQuizId });
                }
            }
            return NotFound();

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            RateYourselfQuizSQ model = _rateYourselfQuizSQRepo.Get(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(RateYourselfQuizSQ model)
        {
            if (ModelState.IsValid)
            {
                RateYourselfQuizS m = _rateYourselfQuizSRepo.Get(model.RateYourselfQuizScriptId);
                if (_rateYourselfQuizSQRepo.Get(model.Id) != null)
                {
                    _rateYourselfQuizSQRepo.Delete(model.Id);
                }
                return RedirectToAction("RateYourselfQuizS", "Admin", new { quizId = m.RateYourselfQuizId });
            }
            return NotFound();
        }
    }
}
