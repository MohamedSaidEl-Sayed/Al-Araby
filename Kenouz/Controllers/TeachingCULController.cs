using Kenouz.Controllers.Helper;
using Kenouz.Models;
using Kenouz.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kenouz.Controllers
{
    [Authorize]
    public class TeachingCULController : Controller
    {
        private readonly IKenouzRepo<TeachingCUL> _teachingCULRepo;
        private readonly ITeachingCRepo _teachingCRepo;
        private readonly ITeachingCULRepo _teachingCULRepo1;
        private readonly CheckCode _checkCode;

        public TeachingCULController(IKenouzRepo<TeachingCUL> teachingCULRepo,ITeachingCRepo teachingCRepo,ITeachingCULRepo teachingCULRepo1, CheckCode checkCode)
        {
            _teachingCULRepo = teachingCULRepo;
            _teachingCRepo = teachingCRepo;
            _teachingCULRepo1 = teachingCULRepo1;
            _checkCode = checkCode;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int classYearId,int id)
        {
            bool IsAllowed = _checkCode.Check(User.Identity.Name).Result;
            if (IsAllowed)
            {
                // to check if the lessonId is really belongs to this class year or not
                bool IsBelongsTo(int lessonId, int yearId)
                {
                    List<int> lessonsOfClassYear = _teachingCULRepo1.GetForUser(yearId);
                    var result = lessonsOfClassYear.FirstOrDefault(id => id == lessonId, 0);
                    return result == 0 ? false : true;

                }
                if (User.IsInRole("User1") && classYearId == 1)
                {
                    if (IsBelongsTo(id, classYearId))
                    {
                        TeachingCUL model = _teachingCULRepo.Get(id);
                        if (model.VideoLink != null)
                        {
                            model.VideoLink = model.VideoLink.Replace("/watch?v=", "/embed/");
                        }
                        return View(model);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else if (User.IsInRole("User2") && classYearId == 2)
                {
                    if (IsBelongsTo(id, classYearId))
                    {
                        TeachingCUL model = _teachingCULRepo.Get(id);
                        if (model.VideoLink != null)
                        {
                            model.VideoLink = model.VideoLink.Replace("/watch?v=", "/embed/");
                        }
                        return View(model);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else if (User.IsInRole("User3") && classYearId == 3)
                {
                    if (IsBelongsTo(id, classYearId))
                    {
                        TeachingCUL model = _teachingCULRepo.Get(id);
                        if (model.VideoLink != null)
                        {
                            model.VideoLink = model.VideoLink.Replace("/watch?v=", "/embed/");
                        }
                        return View(model);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            return NotFound();
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Add(int unitId)
        {
            TeachingCUL model = new TeachingCUL
            {
                TeachingCategoryUnitId = unitId
            };
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(TeachingCUL model)
        {
            if (!ModelState.IsValid)
            {
                return View( model);
            }
            _teachingCULRepo.Add(model);
            return RedirectToAction("TeachingC", "Admin");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            TeachingCUL model = _teachingCULRepo.Get(id);
            if(model != null)
            {
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TeachingCUL model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _teachingCULRepo.Update(model);
            return RedirectToAction("TeachingC", "Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            TeachingCUL teachingCUL = _teachingCULRepo.Get(id);
            if (teachingCUL != null)
            {
                _teachingCULRepo.Delete(id);
            }
            return RedirectToAction("TeachingC", "Admin");
        }
    }
}
