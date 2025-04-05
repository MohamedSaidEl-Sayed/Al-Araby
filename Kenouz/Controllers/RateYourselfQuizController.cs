using Kenouz.Controllers.Helper;
using Kenouz.Models;
using Kenouz.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kenouz.Controllers
{
    [Authorize]
    public class RateYourselfQuizController : Controller
    {
        private readonly IKenouzRepo<RateYourselfQuiz> _rateYourselfRepo;
        private readonly IRateYourselfQuizRepo _rateYourselfRepo1;
        private readonly CheckCode _checkCode;

        public RateYourselfQuizController(IKenouzRepo<RateYourselfQuiz> rateYourselfRepo, IRateYourselfQuizRepo rateYourselfRepo1, CheckCode checkCode)
        {
            _rateYourselfRepo = rateYourselfRepo;
            _rateYourselfRepo1 = rateYourselfRepo1;
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
                    return View(_rateYourselfRepo1.GetForUser(classId));
                }
                else if (User.IsInRole("User2") && classId == 2)
                {
                    ViewData["classYearId"] = classId;
                    return View(_rateYourselfRepo1.GetForUser(classId));
                }
                else if (User.IsInRole("User3") && classId == 3)
                {
                    ViewData["classYearId"] = classId;
                    return View(_rateYourselfRepo1.GetForUser(classId));
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
        public IActionResult Add(RateYourselfQuiz model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("RateYourselfQuiz", "Admin");
            }
            _rateYourselfRepo.Add(model);
            return RedirectToAction("RateYourselfQuiz", "Admin");

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RateYourselfQuiz model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("RateYourselfQuiz", "Admin");
            }
            _rateYourselfRepo.Update(model);
            return RedirectToAction("RateYourselfQuiz", "Admin");

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            RateYourselfQuiz rateYourselfQuiz = _rateYourselfRepo.Get(id);
            if(rateYourselfQuiz is not null)
            {
                _rateYourselfRepo.Delete(id);
            }
            return RedirectToAction("RateYourselfQuiz", "Admin");

        }
    }
}
