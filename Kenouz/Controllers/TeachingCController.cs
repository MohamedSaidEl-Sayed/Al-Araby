using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kenouz.Models.Repositories;
using Kenouz.Models;
using Kenouz.Controllers.Helper;

namespace Kenouz.Controllers
{
    [Authorize]
    public class TeachingCController : Controller
    {
        private readonly IKenouzRepo<TeachingC> _teachingCRepo;
        private readonly ITeachingCRepo _teachingCRepo1;
        private readonly CheckCode _checkCode;

        private readonly ITest _ttest;


        public TeachingCController(IKenouzRepo<TeachingC> teachingCRepo, ITeachingCRepo teachingCRepo1, ITest test, CheckCode checkCode)
        {
            _teachingCRepo = teachingCRepo;
            _teachingCRepo1 = teachingCRepo1;
            _checkCode = checkCode;
            _ttest = test;
        }
        public IActionResult Index(int classId)
        {
            bool IsAllowed = _checkCode.Check(User.Identity.Name).Result;
            if (IsAllowed)
            {
                if (User.IsInRole("User1") && classId == 1)
                {
                    ViewData["classYearId"] = classId;
                    return View(_teachingCRepo1.GetForUser(classId));
                }
                else if (User.IsInRole("User2") && classId == 2)
                {
                    ViewData["classYearId"] = classId;
                    return View(_teachingCRepo1.GetForUser(classId));
                }
                else if (User.IsInRole("User3") && classId == 3)
                {
                    ViewData["classYearId"] = classId;
                    return View(_teachingCRepo1.GetForUser(classId));
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
        public IActionResult Add(TeachingC model)
        {
            if (ModelState.IsValid)
            {
                _teachingCRepo.Add(model);
            }
            return RedirectToAction("TeachingC", "Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TeachingC model)
        {
            if (ModelState.IsValid)
            {
                _teachingCRepo.Update(model);
            }
            return RedirectToAction("TeachingC", "Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            TeachingC teachingC = _teachingCRepo.Get(id);
            if(teachingC != null)
            {
                _teachingCRepo.Delete(id);
            }
            return RedirectToAction("TeachingC", "Admin");
        }
    }
}
