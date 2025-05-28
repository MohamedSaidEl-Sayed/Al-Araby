using Kenouz.Models;
using Kenouz.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kenouz.Controllers
{
    [Authorize]
    public class TeachingCUController : Controller
    {
        private readonly IKenouzRepo<TeachingCU> _teachingCURepo;
        public TeachingCUController(IKenouzRepo<TeachingCU> teachingCURepo)
        {
            _teachingCURepo = teachingCURepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(TeachingCU model)
        {
            if (ModelState.IsValid)
            {
                _teachingCURepo.Add(model);
            }
            return RedirectToAction("TeachingC", "Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TeachingCU model)
        {
            if (ModelState.IsValid)
            {
                _teachingCURepo.Update(model);
            }
            return RedirectToAction("TeachingC", "Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            TeachingCU teachingCU = _teachingCURepo.Get(id);
            if(teachingCU != null)
            {
                _teachingCURepo.Delete(id);
            }
            return RedirectToAction("TeachingC", "Admin");
        }
    }
}
