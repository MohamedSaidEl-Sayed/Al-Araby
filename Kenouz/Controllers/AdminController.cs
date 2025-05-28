using Kenouz.Data;
using Kenouz.Models;
using Kenouz.Models.Repositories;
using Kenouz.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Kenouz.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITeachingCRepo _teachingCRepo;
        private readonly IKenouzRepo<TeachingCUL> _teachingCULRepo;
        private readonly IClassYearRepo _classYearRepo;
        private readonly IQuizPerLessonCRepo _quizPerLessonCRepo;
        private readonly IQuizPerLessonCULQRepo _quizPerLessonCULQRepo;
        private readonly IRateYourselfQuizRepo _rateYourselfQuizRepo;
        private readonly IRateYourselfQuizSRepo _rateYourselfQuizSRepo;
        private readonly IPdfQuizRepo _pdfQuizRepo;
        private readonly Logged_in_Users_DbContext _logged_In_Users;

        static int classYearId =0;//why I use that static (what if I make it instance)
        // I use static because in every time you load an action of these actions(teaching,rateyourself,...),an new instance of AdminController is created
        // and I need classYearId be the same on all these instances

        static int test = 0;

        public AdminController(UserManager<IdentityUser> userManager, 
            ITeachingCRepo teachingCRepo, IKenouzRepo<TeachingCUL> teachingCULRepo, 
            IClassYearRepo classYearRepo,
            IQuizPerLessonCRepo quizPerLessonCRepo, IQuizPerLessonCULQRepo quizPerLessonCULQRepo,
            IRateYourselfQuizRepo rateYourselfQuizRepo, IRateYourselfQuizSRepo rateYourselfQuizSRepo,
            IPdfQuizRepo pdfQuizRepo, Logged_in_Users_DbContext logged_In_Users)
        {
            _userManager = userManager;
            _teachingCRepo = teachingCRepo;
            _teachingCULRepo = teachingCULRepo;
            _classYearRepo = classYearRepo;
            _quizPerLessonCRepo = quizPerLessonCRepo;
            _quizPerLessonCULQRepo = quizPerLessonCULQRepo;
            _rateYourselfQuizRepo = rateYourselfQuizRepo;
            _rateYourselfQuizSRepo = rateYourselfQuizSRepo;
            _pdfQuizRepo = pdfQuizRepo;
            _logged_In_Users = logged_In_Users;
            test++;
        }
       

        public IActionResult Codes()
        {
            List<DeactivatedUser> deactivatedUsers = _logged_In_Users.DeactivatedUsers.ToList();
            List<CodeViewModel> codes = _userManager.Users.Select(u => new CodeViewModel
            {
                Code = u.Email,
                Roles = _userManager.GetRolesAsync(u).Result,
            }).ToList();
            codes.ForEach(c => c.IsActive = !(deactivatedUsers.Any(du => du.UserId == c.Code)) );
            CodesViewModel codesViewModel = new CodesViewModel
            {
                CodeViewModel = codes,
                addCodeViewModel = new AddCodeViewModel()
            };
            return View(codesViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCode(AddCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Codes");
            }
            var user = new IdentityUser()
            {
                UserName = model.Code,
                Email = model.Code
            };
            var result =await _userManager.CreateAsync(user,"#"+model.Code+"#");
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return RedirectToAction("Codes");
            }
            await _userManager.AddToRoleAsync(user, model.Role);
            return RedirectToAction("Codes");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateCode(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
           
            if (user != null)
            {
                var deactivatedUser = new DeactivatedUser
                {
                    UserId = user.Email
                };
                var loggedInUser = new Logged_in_Users
                {
                    UserID = user.Id
                };
                var result =await _userManager.UpdateSecurityStampAsync(user);
                if (result.Succeeded)
                {
                    var l = _logged_In_Users.Logged_In_Users.AsNoTracking().FirstOrDefault(l => l.UserID == loggedInUser.UserID);
                    var d = _logged_In_Users.DeactivatedUsers.AsNoTracking().FirstOrDefault(d => d.UserId == deactivatedUser.UserId);

                    if (l is not null && d is null) 
                    { 
                        _logged_In_Users.DeactivatedUsers.Add(deactivatedUser);
                        _logged_In_Users.Logged_In_Users.Remove(loggedInUser);
                        _logged_In_Users.SaveChanges();
                    }
                    return RedirectToAction("Codes", "Admin");
                }
                return NotFound();
                
            }
            return RedirectToAction("Codes", "Admin");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActivateCode(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var deactivatedUser = new DeactivatedUser
                {
                    UserId = user.Email
                };
                if(_logged_In_Users.DeactivatedUsers.AsNoTracking().FirstOrDefault(d => d.UserId == deactivatedUser.UserId) != null)
                {
                    _logged_In_Users.DeactivatedUsers.Remove(deactivatedUser);
                    _logged_In_Users.SaveChanges();
                }
                return RedirectToAction("Codes", "Admin");
            }
            return RedirectToAction("Codes", "Admin");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCode(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var l = _logged_In_Users.Logged_In_Users.AsNoTracking().FirstOrDefault(l => l.UserID == user.Id);
                var d = _logged_In_Users.DeactivatedUsers.AsNoTracking().FirstOrDefault(d => d.UserId == user.Email);

                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    if (l is not null)
                    {
                        _logged_In_Users.Logged_In_Users.Remove(l);
                    }
                    if (d is not null)
                    {
                        _logged_In_Users.DeactivatedUsers.Remove(d);
                    }
                    _logged_In_Users.SaveChanges();
                    return RedirectToAction("Codes", "Admin");
                }
            }
            return NotFound();
        }
        public IActionResult Index(int id)
        {
            string year = "";
            if (id == 1)
            {
                year = "الصف الأول الثانوي";
            }
            else if (id == 2)
            {
                year = "الصف الثاني الثانوي";
            }
            else if (id == 3)
            {
                year = "الصف الثالث الثانوي";
            }
            else
            {
                return NotFound();
            }
            classYearId = _classYearRepo.GetByName(year).Id;
            return View();
        }

        public IActionResult TeachingC()
        {
            AdminTeachingCViewModel model = new AdminTeachingCViewModel();
            model.teachingCs = _teachingCRepo.GetForUser(classYearId);
            ViewData["ClassYearId"] = classYearId;
            if (classYearId != 0)
            {
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult TeachingCUL(int id)
        {
            TeachingCUL model = _teachingCULRepo.Get(id);
            if (model.VideoLink != null)
            {
                model.VideoLink = model.VideoLink.Replace("/watch?v=", "/embed/");
            }
            return View(model);
        }

        public IActionResult QuizPerLessonC()
        {
            AdminQuizPerLessonCViewModel model = new AdminQuizPerLessonCViewModel();
            model.quizPerLessonCs = _quizPerLessonCRepo.GetForUser(classYearId);
            ViewData["ClassYearId"] = classYearId;
            if (classYearId != 0)
            {
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult QuizPerLessonCULQ(int id)
        {
            AdminQuizPerLessonCULQViewModel adminQuizPerLessonCULQViewModel = new AdminQuizPerLessonCULQViewModel
            {
                quizPerLessonCULQs = _quizPerLessonCULQRepo.GetForLesson(id)
            };
            ViewData["lessonid"] = id;
            return View(adminQuizPerLessonCULQViewModel);
        }
       
        public IActionResult RateYourselfQuiz()
        {
            AdminRateYourselfQuizViewModel adminRateYourselfQuizViewModel = new AdminRateYourselfQuizViewModel
            {
                rateYourselfQuizzes = _rateYourselfQuizRepo.GetForUser(classYearId)
            };
            ViewData["ClassYearId"] = classYearId;
            if (classYearId != 0)
            {
                return View(adminRateYourselfQuizViewModel);
            }
            else
            {
                return NotFound();
            }

        }

        public IActionResult RateYourselfQuizS(int quizId)
        {
            AdminRateYourselfQuizSViewModel adminRateYourselfQuizSViewModel = new AdminRateYourselfQuizSViewModel
            {
                rateYourselfQuizSs = JsonConvert.SerializeObject(
                  _rateYourselfQuizSRepo.GetForQuiz(quizId), Formatting.Indented,
                  new JsonSerializerSettings(){ReferenceLoopHandling = ReferenceLoopHandling.Ignore})
            };
            ViewData["quizId"] = quizId;
            return View(adminRateYourselfQuizSViewModel);
        }

        public IActionResult PdfQuiz()
        {
            AdminPdfQuizViewModel adminPdfQuizViewModel = new AdminPdfQuizViewModel
            {
                pdfQuizzes = _pdfQuizRepo.GetForUser(classYearId)
            };
            ViewData["ClassYearId"] = classYearId;
            if (classYearId != 0)
            {
                return View(adminPdfQuizViewModel);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
