using Kenouz.Controllers.Helper;
using Kenouz.Models;
using Kenouz.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kenouz.Controllers
{
    [Authorize]
    public class PdfQuizController : Controller
    {
        private readonly IKenouzRepo<PdfQuiz> _pdfQuizRepo;
        private readonly IPdfQuizRepo _pdfQuizRepo1;
        private readonly CheckCode _checkCode;

        public PdfQuizController(IKenouzRepo<PdfQuiz> pdfQuizRepo, IPdfQuizRepo pdfQuizRepo1, CheckCode checkCode)
        {
            _pdfQuizRepo = pdfQuizRepo;
            _pdfQuizRepo1 = pdfQuizRepo1;
            _checkCode = checkCode;
        }
        public IActionResult Index(int classId)
        {
            bool IsAllowed = _checkCode.Check(User.Identity.Name).Result;
            if (IsAllowed)
            {
                if (User.IsInRole("User1") && classId == 1)
                {
                    return View(_pdfQuizRepo1.GetForUser(classId));
                }
                else if (User.IsInRole("User2") && classId == 2)
                {
                    return View(_pdfQuizRepo1.GetForUser(classId));
                }
                else if (User.IsInRole("User3") && classId == 3)
                {
                    return View(_pdfQuizRepo1.GetForUser(classId));
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
        public IActionResult Add(PdfQuiz model)
        {
            if (ModelState.IsValid)
            {
                _pdfQuizRepo.Add(model);
            }
            return RedirectToAction("PdfQuiz", "Admin");

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PdfQuiz model)
        {
            if (ModelState.IsValid)
            {
                _pdfQuizRepo.Update(model);
            }
            return RedirectToAction("PdfQuiz", "Admin");

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            PdfQuiz pdfQuiz = _pdfQuizRepo.Get(id);
            if(pdfQuiz is not null)
            {
                _pdfQuizRepo.Delete(id);
            }
            return RedirectToAction("PdfQuiz", "Admin");

        }
    }
}
