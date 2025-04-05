using Kenouz.Controllers.Helper;
using Kenouz.Models;
using Kenouz.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kenouz.Controllers
{
    [Authorize]
    public class RateYourselfQuizSController : Controller
    {
        private readonly IKenouzRepo<RateYourselfQuizS> _rateYourselfQuizSRepo;
        private readonly IRateYourselfQuizSRepo _rateYourselfQuizSRepo1;
        private readonly IKenouzRepo<RateYourselfQuiz> _rateYourselfQuizRepo;
        private readonly IRateYourselfQuizRepo _rateYourselfQuizRepo1;
        private readonly CheckCode _checkCode;

        public RateYourselfQuizSController(IKenouzRepo<RateYourselfQuizS> rateYourselfQuizSRepo, 
                                            IRateYourselfQuizSRepo rateYourselfQuizSRepo1,
                                            IKenouzRepo<RateYourselfQuiz> rateYourselfQuizRepo,
                                            IRateYourselfQuizRepo rateYourselfQuizRepo1,
                                            CheckCode checkCode)
        {
            _rateYourselfQuizSRepo = rateYourselfQuizSRepo;
            _rateYourselfQuizSRepo1 = rateYourselfQuizSRepo1;
            _rateYourselfQuizRepo = rateYourselfQuizRepo;
            _rateYourselfQuizRepo1 = rateYourselfQuizRepo1;
            _checkCode = checkCode;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int quizId, int classYearId)
        {
            bool IsAllowed = _checkCode.Check(User.Identity.Name).Result;
            if (IsAllowed)
            {
                bool IsBelongsTo(int quizId, int yearId)
                {
                    List<int> quizIds = new List<int>();
                    List<RateYourselfQuiz> quizzesOfYearId = _rateYourselfQuizRepo1.GetForUser(yearId);
                    foreach (var quiz in quizzesOfYearId)
                    {
                        quizIds.Add(quiz.Id);
                    }
                    return quizIds.Contains(quizId);
                }
                if (User.IsInRole("User1") && classYearId == 1)
                {
                    if (IsBelongsTo(quizId, classYearId))
                    {
                        ViewData["QuizTime"] = _rateYourselfQuizRepo.Get(quizId).Time;
                        return View(_rateYourselfQuizSRepo1.GetForQuiz(quizId));
                    }
                    return NotFound();

                }
                else if (User.IsInRole("User2") && classYearId == 2)
                {
                    if (IsBelongsTo(quizId, classYearId))
                    {
                        ViewData["QuizTime"] = _rateYourselfQuizRepo.Get(quizId).Time;
                        return View(_rateYourselfQuizSRepo1.GetForQuiz(quizId));
                    }
                    return NotFound();
                }
                else if (User.IsInRole("User3") && classYearId == 3)
                {
                    if (IsBelongsTo(quizId, classYearId))
                    {
                        ViewData["QuizTime"] = _rateYourselfQuizRepo.Get(quizId).Time;
                        return View(_rateYourselfQuizSRepo1.GetForQuiz(quizId));
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
        public IActionResult Add(RateYourselfQuizS model)
        {
            if (ModelState.IsValid)
            {
                _rateYourselfQuizSRepo.Add(model);
                return RedirectToAction("RateYourselfQuizS", "Admin", new { quizId = model.RateYourselfQuizId });
            }
            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            RateYourselfQuizS model = _rateYourselfQuizSRepo.Get(id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RateYourselfQuizS model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _rateYourselfQuizSRepo.Update(model);
            return RedirectToAction("RateYourselfQuizS", "Admin", new { quizId = model.RateYourselfQuizId });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            RateYourselfQuizS model = _rateYourselfQuizSRepo.Get(id);
            if (model is not null)
            {
                _rateYourselfQuizSRepo.Delete(id);
                return RedirectToAction("RateYourselfQuizS", "Admin", new { quizId = model.RateYourselfQuizId });
            }
            return NotFound();
        }
    }
}
