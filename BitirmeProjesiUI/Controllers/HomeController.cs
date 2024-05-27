using DataAccessLayer.Models;
using EntityLayer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AspNetCoreIdentityApp.Web.Extenisons; 
using System.Security.Claims; 
using DataAccessLayer.Services;
using BussinessLayer.Abstract;
using Newtonsoft.Json.Linq;
using Azure.Core;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Pit2mKurumsalWebSiteUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _UserManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;
         

        private readonly IDepartmentService _departmentService;
        private readonly IInstructorService _ınstructorService;
        private readonly IProjectService _projectService;
        private readonly ITeamService _teamService;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService, IDepartmentService departmentService, IInstructorService ınstructorService, IProjectService projectService, ITeamService teamService)
        {
            _logger = logger;
            _UserManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _departmentService = departmentService;
            _ınstructorService = ınstructorService;
            _projectService = projectService;
            _teamService = teamService;
        }

        public async Task < IActionResult> Index()
        {
            string userName = User.Identity.Name;
            var hasUser = await _UserManager.FindByNameAsync(userName);
            var userID = hasUser.Id;

            var user = await _UserManager.FindByIdAsync(userID);
            if (user == null)
            {
                // Kullanıcı bulunamadı
                return NotFound();
            }

            var roles = await _UserManager.GetRolesAsync(user);
            int totalRoleCount = roles.Count;


            var UserDepartment = _departmentService.TGetList().Count();
            ViewBag.UserDepartment_V = UserDepartment;

            //var UserCount = _ınstructorService.Users.Count();
            //ViewBag.UserCount_V = UserCount;

             var ProjectCount = _projectService.TGetList().Count();
             ViewBag.ProjectCount_V = ProjectCount;

            var TeamCount = _teamService.TGetList().Count();
            ViewBag.TeamCount_V = TeamCount;


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            List<SelectListItem> Department_Values = ( _departmentService.TGetList()).Where(x => x.IsActive == true)
                                   .Select(x => new SelectListItem
                                   {
                                       Text = x.Department_Name,
                                       Value = x.Department_ID.ToString()
                                   })
                                   .ToList();
            ViewBag.Department_Values_V = Department_Values;
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            returnUrl ??= Url.Action("Index", "Home");

            var hasUserRole = await _UserManager.FindByIdAsync(model.Email);
            
            var hasUser = await _UserManager.FindByEmailAsync(model.Email);

            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email or password is wrong");
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(hasUser, model.Password, model.RememberMe, true);

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() { "3 minute timeout" });
                return View();
            }

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelErrorList(new List<string>() { $"Email or password is wrong", $"Failed attempt count = {await _UserManager.GetAccessFailedCountAsync(hasUser)}" });
                return View();
            }
           
            if(hasUser.BirthDate.HasValue)
            {
                await _signInManager.SignInWithClaimsAsync(hasUser, model.RememberMe, new[] { new Claim("birthdate", hasUser.BirthDate.Value.ToString()) });
            }
            return Redirect(returnUrl!);

        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {

            List<SelectListItem> Department_Values = (await _departmentService.TGetListAllAsync()).Where(x => x.IsActive == true)
                                         .Select(x => new SelectListItem
                                         {
                                             Text = x.Department_Name,
                                             Value = x.Department_ID.ToString()
                                         })
                                         .ToList();
            ViewBag.Department_Values_V = Department_Values;

            if (!ModelState.IsValid)
            {
                return View();
            }

            var identityResult = await _UserManager.CreateAsync(new() {Department_ID=request.Department_ID, IsActive = request.IsActive, UserName = request.UserName, Name = request.Name, SurName = request.SurName, PhoneNumber = request.Phone, Email = request.Email }, request.PasswordConfirm);


            if (!identityResult.Succeeded)
            {
                ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());
                return View();
            }

            var exchangeExpireClaim = new Claim("ExchangeExpireDate", DateTime.Now.AddDays(10).ToString());

            var user = await _UserManager.FindByNameAsync(request.UserName);

            var claimResult = await _UserManager.AddClaimAsync(user!, exchangeExpireClaim);
 

            if(!claimResult.Succeeded)
            {
                ModelState.AddModelErrorList(claimResult.Errors.Select(x => x.Description).ToList());
                return View();
            }


            TempData["SuccessMessage"] = "User created successfully.";

            return RedirectToAction(nameof(HomeController.SignUp));
             

        }
         

        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel request)
        {
            var hasUser = await _UserManager.FindByEmailAsync(request.Email);
            if (hasUser == null)
            {
                ModelState.AddModelError(String.Empty, "User not found registered with this email.");
                return View();
            }
            string passwordResestToken = await _UserManager.GeneratePasswordResetTokenAsync(hasUser);

            var passwordResetLink = Url.Action("ResetPassword", "Home", new { userId = hasUser.Id, Token = passwordResestToken }, HttpContext.Request.Scheme);
            //örnek link https://localhost:7006?userId=12213&token=aajsdfjdsalkfjkdsfj

            await _emailService.SendResetPasswordEmail(passwordResetLink!, hasUser.Email!);

            TempData["SuccessMessage"] = "Password change link sent";

            return RedirectToAction(nameof(ForgetPassword));
        }

        public IActionResult ResetPassword(string userId, string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel request)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];

            if (userId == null || token == null)
            {
                throw new Exception("An error occured");
            }

            var hasUser = await _UserManager.FindByIdAsync(userId.ToString()!);

            if (hasUser == null)
            {
                ModelState.AddModelError(String.Empty, "User not found.");
                return View();
            }

            IdentityResult result = await _UserManager.ResetPasswordAsync(hasUser, token.ToString()!, request.Password);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Password changed successfully";
            }
            else
            {
                ModelState.AddModelErrorList(result.Errors.Select(x => x.Description).ToList());
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult GetOptimizationPythonKod()
        {

            ProcessStartInfo pr = new ProcessStartInfo();
            pr.FileName = "wwwroot/Module/Module.exe"; 
             
            pr.Arguments = "";
            Process p = new Process();
            p.StartInfo = pr;
            p.Start();

            return View(nameof(Index));
        }
    }
}