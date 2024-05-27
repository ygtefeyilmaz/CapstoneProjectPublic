using AutoMapper;
using BitirmeProjesi.Areas.Admin.Models;
using BitirmeProjesiUI.Models.Team;
using BussinessLayer.Abstract;
using BussinessLayer.ValidaitonsRules;
using DataAccessLayer.Models;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace BitirmeProjesiUI.Controllers
{
    public class TeamController : Controller
    {
        private readonly UserManager<AppUser> _UserManager;
        private readonly RoleManager<AppRole> _RoleManager;
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        private readonly ITeamService _teamService;

        private readonly IProjectService _projectService;
        private readonly IStudentService _studentService;
        private readonly ILoggerService _loggerService;

        public TeamController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IDepartmentService departmentService, ITeamService teamService, IProjectService projectService, IStudentService studentService, ILoggerService loggerService)
        {
            _UserManager = userManager;
            _RoleManager = roleManager;
            _mapper = mapper;
            _departmentService = departmentService;
            _teamService = teamService;
            _projectService = projectService;
            _studentService = studentService;
            _loggerService = loggerService;
        }

        public IActionResult Index()
        {
            var value = _teamService.TGetList();
            _loggerService.Info("Listeleme sayfasına geldi");


            return View(value);
        }



        [HttpGet]
        public async Task<IActionResult> AddTeam()
        {
            await GetDropList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTeam(Team p)
        {
            try
            {
                await GetDropList();
                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);
                var userID = hasUser.Id;
                var user = await _UserManager.FindByIdAsync(userID);
                var roles = await _UserManager.GetRolesAsync(user);
                var getRole = roles.FirstOrDefault();

                TeamValidator bcv = new TeamValidator();
                ValidationResult result = bcv.Validate(p);
                if (result.IsValid)
                {
                    if (p.projectChoice1 == p.projectChoice2 || p.projectChoice1 == p.projectChoice3 || p.projectChoice1 == p.projectChoice4 || p.projectChoice1 == p.projectChoice5 || p.projectChoice1 == p.projectChoice6 || p.projectChoice1 == p.projectChoice7 || p.projectChoice1 == p.projectChoice8 || p.projectChoice1 == p.projectChoice9 || p.projectChoice1 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else if (p.projectChoice2 == p.projectChoice1 || p.projectChoice2 == p.projectChoice3 || p.projectChoice2 == p.projectChoice4 || p.projectChoice2 == p.projectChoice5 || p.projectChoice2 == p.projectChoice6 || p.projectChoice2 == p.projectChoice7 || p.projectChoice2 == p.projectChoice8 || p.projectChoice2 == p.projectChoice9 || p.projectChoice2 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else if (p.projectChoice3 == p.projectChoice1 || p.projectChoice3 == p.projectChoice2 || p.projectChoice3 == p.projectChoice4 || p.projectChoice3 == p.projectChoice5 || p.projectChoice3 == p.projectChoice6 || p.projectChoice3 == p.projectChoice7 || p.projectChoice3 == p.projectChoice8 || p.projectChoice3 == p.projectChoice9 || p.projectChoice3 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else if (p.projectChoice4 == p.projectChoice1 || p.projectChoice4 == p.projectChoice2 || p.projectChoice4 == p.projectChoice3 || p.projectChoice4 == p.projectChoice5 || p.projectChoice4 == p.projectChoice6 || p.projectChoice4 == p.projectChoice7 || p.projectChoice4 == p.projectChoice8 || p.projectChoice4 == p.projectChoice9 || p.projectChoice4 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else if (p.projectChoice5 == p.projectChoice1 || p.projectChoice5 == p.projectChoice2 || p.projectChoice5 == p.projectChoice3 || p.projectChoice5 == p.projectChoice4 || p.projectChoice5 == p.projectChoice6 || p.projectChoice5 == p.projectChoice7 || p.projectChoice5 == p.projectChoice8 || p.projectChoice5 == p.projectChoice9 || p.projectChoice5 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else if (p.projectChoice6 == p.projectChoice1 || p.projectChoice6 == p.projectChoice2 || p.projectChoice6 == p.projectChoice3 || p.projectChoice6 == p.projectChoice4 || p.projectChoice6 == p.projectChoice5 || p.projectChoice6 == p.projectChoice7 || p.projectChoice6 == p.projectChoice8 || p.projectChoice6 == p.projectChoice9 || p.projectChoice6 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else if (p.projectChoice7 == p.projectChoice1 || p.projectChoice7 == p.projectChoice2 || p.projectChoice7 == p.projectChoice3 || p.projectChoice7 == p.projectChoice4 || p.projectChoice7 == p.projectChoice5 || p.projectChoice7 == p.projectChoice6 || p.projectChoice7 == p.projectChoice8 || p.projectChoice7 == p.projectChoice9 || p.projectChoice7 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else if (p.projectChoice8 == p.projectChoice1 || p.projectChoice8 == p.projectChoice2 || p.projectChoice8 == p.projectChoice3 || p.projectChoice8 == p.projectChoice4 || p.projectChoice8 == p.projectChoice5 || p.projectChoice8 == p.projectChoice6 || p.projectChoice8 == p.projectChoice7 || p.projectChoice8 == p.projectChoice9 || p.projectChoice8 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }

                    else if (p.projectChoice9 == p.projectChoice1 || p.projectChoice9 == p.projectChoice2 || p.projectChoice9 == p.projectChoice3 || p.projectChoice9 == p.projectChoice4 || p.projectChoice9 == p.projectChoice5 || p.projectChoice9 == p.projectChoice6 || p.projectChoice9 == p.projectChoice7 || p.projectChoice9 == p.projectChoice8 || p.projectChoice9 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }

                    else if (p.projectChoice10 == p.projectChoice1 || p.projectChoice10 == p.projectChoice2 || p.projectChoice10 == p.projectChoice3 || p.projectChoice10 == p.projectChoice4 || p.projectChoice10 == p.projectChoice5 || p.projectChoice10 == p.projectChoice6 || p.projectChoice10 == p.projectChoice7 || p.projectChoice10 == p.projectChoice9 || p.projectChoice10 == p.projectChoice9)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else
                    {

                        p.Team_Name = p.Team_Name;
                        p.AssignedProjectID = 0;
                        p.Department_ID = p.Department_ID;
                        p.Team_Capacity = p.Team_Capacity;
                        p.Team_Description = p.Team_Description;

                        p.projectChoice1 = p.projectChoice1;
                        p.projectChoice2 = p.projectChoice2;
                        p.projectChoice3 = p.projectChoice3;
                        p.projectChoice4 = p.projectChoice4;
                        p.projectChoice5 = p.projectChoice5;
                        p.projectChoice6 = p.projectChoice6;
                        p.projectChoice7 = p.projectChoice7;
                        p.projectChoice8 = p.projectChoice8;
                        p.projectChoice9 = p.projectChoice9;
                        p.projectChoice10 = p.projectChoice10;

                        p.studentID1 = p.studentID1;
                        p.studentID2 = p.studentID2;
                        p.studentID3 = p.studentID3;

                        p.Create_ID = hasUser.Id;
                        p.Create_Date = DateTime.Now;
                        p.Update_ID = null;
                        p.Update_Date = DateTime.Now;

                        p.IsDelete = false;
                        p.IsDelete_ID = null;
                        p.IsDelete_Date = DateTime.Now;
                        p.IsActive = true;

                        _teamService.TAdd(p);
                    }
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        //hata mesajı ve log yaz
                    }
                    return View();
                }


                if (getRole == "AdminRole")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("StudentIndex");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        public async Task<IActionResult> UpdateTeam(int id)
        {
            try
            {
                await GetDropList();
                // await Task.Delay(TimeSpan.FromSeconds(5));
                var values = _teamService.TGetById(id);

                ViewBag.studentID1_V = values.studentID1;
                ViewBag.studentID2_V = values.studentID2;
                ViewBag.studentID3_V = values.studentID3;

                var result = _mapper.Map<UpdateTeamModel>(values);

                return View(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeam(Team p, int id)
        {
            try
            {
                await GetDropList();
                //  await Task.Delay(TimeSpan.FromSeconds(5));
                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);

                TeamValidator bcv = new TeamValidator();
                ValidationResult result = bcv.Validate(p);
                if (result.IsValid)
                {
                    if (p.projectChoice1 == p.projectChoice2 || p.projectChoice1 == p.projectChoice3 || p.projectChoice1 == p.projectChoice4 || p.projectChoice1 == p.projectChoice5 || p.projectChoice1 == p.projectChoice6 || p.projectChoice1 == p.projectChoice7 || p.projectChoice1 == p.projectChoice8 || p.projectChoice1 == p.projectChoice9 || p.projectChoice1 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else if (p.projectChoice2 == p.projectChoice1 || p.projectChoice2 == p.projectChoice3 || p.projectChoice2 == p.projectChoice4 || p.projectChoice2 == p.projectChoice5 || p.projectChoice2 == p.projectChoice6 || p.projectChoice2 == p.projectChoice7 || p.projectChoice2 == p.projectChoice8 || p.projectChoice2 == p.projectChoice9 || p.projectChoice2 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else if (p.projectChoice3 == p.projectChoice1 || p.projectChoice3 == p.projectChoice2 || p.projectChoice3 == p.projectChoice4 || p.projectChoice3 == p.projectChoice5 || p.projectChoice3 == p.projectChoice6 || p.projectChoice3 == p.projectChoice7 || p.projectChoice3 == p.projectChoice8 || p.projectChoice3 == p.projectChoice9 || p.projectChoice3 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else if (p.projectChoice4 == p.projectChoice1 || p.projectChoice4 == p.projectChoice2 || p.projectChoice4 == p.projectChoice3 || p.projectChoice4 == p.projectChoice5 || p.projectChoice4 == p.projectChoice6 || p.projectChoice4 == p.projectChoice7 || p.projectChoice4 == p.projectChoice8 || p.projectChoice4 == p.projectChoice9 || p.projectChoice4 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else if (p.projectChoice5 == p.projectChoice1 || p.projectChoice5 == p.projectChoice2 || p.projectChoice5 == p.projectChoice3 || p.projectChoice5 == p.projectChoice4 || p.projectChoice5 == p.projectChoice6 || p.projectChoice5 == p.projectChoice7 || p.projectChoice5 == p.projectChoice8 || p.projectChoice5 == p.projectChoice9 || p.projectChoice5 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else if (p.projectChoice6 == p.projectChoice1 || p.projectChoice6 == p.projectChoice2 || p.projectChoice6 == p.projectChoice3 || p.projectChoice6 == p.projectChoice4 || p.projectChoice6 == p.projectChoice5 || p.projectChoice6 == p.projectChoice7 || p.projectChoice6 == p.projectChoice8 || p.projectChoice6 == p.projectChoice9 || p.projectChoice6 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else if (p.projectChoice7 == p.projectChoice1 || p.projectChoice7 == p.projectChoice2 || p.projectChoice7 == p.projectChoice3 || p.projectChoice7 == p.projectChoice4 || p.projectChoice7 == p.projectChoice5 || p.projectChoice7 == p.projectChoice6 || p.projectChoice7 == p.projectChoice8 || p.projectChoice7 == p.projectChoice9 || p.projectChoice7 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else if (p.projectChoice8 == p.projectChoice1 || p.projectChoice8 == p.projectChoice2 || p.projectChoice8 == p.projectChoice3 || p.projectChoice8 == p.projectChoice4 || p.projectChoice8 == p.projectChoice5 || p.projectChoice8 == p.projectChoice6 || p.projectChoice8 == p.projectChoice7 || p.projectChoice8 == p.projectChoice9 || p.projectChoice8 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }

                    else if (p.projectChoice9 == p.projectChoice1 || p.projectChoice9 == p.projectChoice2 || p.projectChoice9 == p.projectChoice3 || p.projectChoice9 == p.projectChoice4 || p.projectChoice9 == p.projectChoice5 || p.projectChoice9 == p.projectChoice6 || p.projectChoice9 == p.projectChoice7 || p.projectChoice9 == p.projectChoice8 || p.projectChoice9 == p.projectChoice10)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }

                    else if (p.projectChoice10 == p.projectChoice1 || p.projectChoice10 == p.projectChoice2 || p.projectChoice10 == p.projectChoice3 || p.projectChoice10 == p.projectChoice4 || p.projectChoice10 == p.projectChoice5 || p.projectChoice10 == p.projectChoice6 || p.projectChoice10 == p.projectChoice7 || p.projectChoice10 == p.projectChoice9 || p.projectChoice10 == p.projectChoice9)
                    {
                        TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                        return View();
                    }
                    else
                    {

                        var value = _teamService.TGetById(id);

                        p.Team_ID = id;
                        p.Team_Name = p.Team_Name;
                        p.AssignedProjectID = 0;
                        p.Department_ID = p.Department_ID;
                        p.Team_Capacity = p.Team_Capacity;
                        p.Team_Description = p.Team_Description;

                        p.projectChoice1 = p.projectChoice1;
                        p.projectChoice2 = p.projectChoice2;
                        p.projectChoice3 = p.projectChoice3;
                        p.projectChoice4 = p.projectChoice4;
                        p.projectChoice5 = p.projectChoice5;
                        p.projectChoice6 = p.projectChoice6;
                        p.projectChoice7 = p.projectChoice7;
                        p.projectChoice8 = p.projectChoice8;
                        p.projectChoice9 = p.projectChoice9;
                        p.projectChoice10 = p.projectChoice10;

                        p.studentID1 = p.studentID1;
                        p.studentID2 = p.studentID2;
                        p.studentID3 = p.studentID3;

                        p.Create_ID = value.Create_ID;
                        p.Create_Date = value.Create_Date;
                        p.Update_ID = hasUser.Id;
                        p.Update_Date = DateTime.Now;

                        p.IsDelete = value.IsDelete;
                        p.IsDelete_ID = value.IsDelete_ID;
                        p.IsDelete_Date = value.IsDelete_Date;
                        p.IsActive = p.IsActive;


                        _teamService.TUpdate(p);

                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        //hata mesajı ve log yaz
                    }
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult DeleteTeam(int id)
        {
            var value = _teamService.TGetById(id);
            _teamService.TDelete(value);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> GetDropList()
        {

            string userName = User.Identity.Name;
            var hasUser = _UserManager.FindByNameAsync(userName).Result;
            var GetDepartmentID = hasUser.Department_ID;


            List<SelectListItem> Department_Values = (await _departmentService.TGetListAllAsync()).Where(x => x.IsActive == true)
                                             .Select(x => new SelectListItem
                                             {
                                                 Text = x.Department_Name,
                                                 Value = x.Department_ID.ToString()
                                             })
                                             .ToList();
            ViewBag.Department_Values_V = Department_Values;


            //Sisteme giren kullanıcının olduğu departmanlar
            List<SelectListItem> GetDepartment_Values = (await _departmentService.TGetListAllAsync()).Where(x => x.IsActive == true).Where(x => x.Department_ID == GetDepartmentID)
                                          .Select(x => new SelectListItem
                                          {
                                              Text = x.Department_Name,
                                              Value = x.Department_ID.ToString()
                                          })
                                          .ToList();
            ViewBag.GetDepartment_Values_V = GetDepartment_Values;


            //deapartman ID öğrencinin departmanınına uytan bütün deprtmanlar gelecek(dep1-2-3)

            List<SelectListItem> GetProjectDepID_Values = (await _projectService.TGetListAllAsync()).Where(x => x.IsActive == true).Where(x => x.Department_ID == GetDepartmentID || x.DepartmentID2 == GetDepartmentID || x.DepartmentID3 == GetDepartmentID || x.DepartmentID4 == GetDepartmentID)
                                    .Select(x => new SelectListItem
                                    {
                                        Text = x.Project_Name,
                                        Value = x.Project_ID.ToString()
                                    })
                                    .ToList();
            ViewBag.GetProjectDepID_Values_V = GetProjectDepID_Values;




            List<SelectListItem> Project_Values = (await _projectService.TGetListAllAsync()).Where(x => x.IsActive == true)
                                         .Select(x => new SelectListItem
                                         {
                                             Text = x.Project_Name,
                                             Value = x.Project_ID.ToString()
                                         })
                                         .ToList();
            ViewBag.Project_Values_V = Project_Values;

            //Sisteme otantike olan kullanıcının departmanında ki projeler
            List<SelectListItem> GetProject_Values = (await _projectService.TGetListAllAsync()).Where(x => x.IsActive == true).Where(x => x.Department_ID == GetDepartmentID)
                                      .Select(x => new SelectListItem
                                      {
                                          Text = x.Project_Name,
                                          Value = x.Project_ID.ToString()
                                      })
                                      .ToList();
            ViewBag.GetProject_Values_V = GetProject_Values;


            List<SelectListItem> GetStudentName_Values = (await _UserManager.Users.ToListAsync()).Where(x => x.UserName == userName)
                                    .Select(x => new SelectListItem
                                    {
                                        Text = x.Name + " " + x.SurName,
                                        Value = x.Id.ToString()
                                    })
                                    .ToList();
            ViewBag.GetStudentName_Values_V = GetStudentName_Values;

            List<SelectListItem> GetAllStudent_Values = (await _UserManager.Users.ToListAsync())
                                   .Select(x => new SelectListItem
                                   {
                                       Text = x.Name + " " + x.SurName,
                                       Value = x.Id.ToString()
                                   })
                                   .ToList();
            ViewBag.GetAllStudent_Values_V = GetAllStudent_Values;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> StudentIndex()
        {
            string userName = User.Identity.Name;
            var hasUser = await _UserManager.FindByNameAsync(userName);
            var DepartmentID = hasUser.Department_ID;


            var depName = _departmentService.TGetById(DepartmentID).Department_Name;
            ViewBag.depName_V = depName;

            var value = _teamService.TGetList().Where(x => x.Department_ID == DepartmentID).ToList();
            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStudentTeam(int id) //Sadsece öğrenciler 
        {
            try
            {
                await GetDropList();
                var values = _teamService.TGetById(id);
                // await Task.Delay(TimeSpan.FromSeconds(5));
                ViewBag.studentID1_V = values.studentID1;
                ViewBag.studentID2_V = values.studentID2;
                ViewBag.studentID3_V = values.studentID3;

                var result = _mapper.Map<UpdateTeamModel>(values);

                return View(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudentTeam(Team p, int id)
        {
            try
            {
                await GetDropList();
                //  await Task.Delay(TimeSpan.FromSeconds(5));
                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);

                TeamValidator bcv = new TeamValidator();
                ValidationResult result = bcv.Validate(p);

                //if (result.IsValid)
                //{
                    var value = _teamService.TGetById(id);
                    p.Team_ID = id;
                    p.Team_Name = value.Team_Name;
                    p.AssignedProjectID = 0;
                    p.Department_ID = value.Department_ID;
                    p.Team_Capacity = value.Team_Capacity;
                    p.Team_Description = value.Team_Description;

                    p.projectChoice1 = value.projectChoice1;
                    p.projectChoice2 = value.projectChoice2;
                    p.projectChoice3 = value.projectChoice3;
                    p.projectChoice4 = value.projectChoice4;
                    p.projectChoice5 = value.projectChoice5;
                    p.projectChoice6 = value.projectChoice6;
                    p.projectChoice7 = value.projectChoice7;
                    p.projectChoice8 = value.projectChoice8;
                    p.projectChoice9 = value.projectChoice9;
                    p.projectChoice10 = value.projectChoice10;



                    if (value.studentID1 == null || value.studentID1 == hasUser.Id)
                    {
                        p.studentID1 = p.studentID1;
                    }
                    else
                    {
                        p.studentID1 = value.studentID1;
                    }

                    if (value.studentID2 == null || value.studentID2 == hasUser.Id)
                    {
                        p.studentID2 = p.studentID2;
                    }
                    else
                    {
                        p.studentID2 = value.studentID2;
                    }

                    if (value.studentID3 == null || value.studentID3 == hasUser.Id)
                    {
                        p.studentID3 = p.studentID3;
                    }
                    else
                    {
                        p.studentID3 = value.studentID3;
                    }

                    p.Create_ID = value.Create_ID;
                    p.Create_Date = value.Create_Date;
                    p.Update_ID = hasUser.Id;
                    p.Update_Date = DateTime.Now;

                    p.IsDelete = value.IsDelete;
                    p.IsDelete_ID = value.IsDelete_ID;
                    p.IsDelete_Date = value.IsDelete_Date;
                    p.IsActive = p.IsActive;


                    _teamService.TUpdate(p);

                    return RedirectToAction("StudentIndex");
                //}
                //else
                //{
                //    foreach (var item in result.Errors)
                //    {
                //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                //        //hata mesajı ve log yaz
                //    }
                //}
                //return View();
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        public async Task<IActionResult> UpdateStudentProject(int id) //Sadsece öğrenciler 
        {
            try
            {
                await GetDropList();
                //   await Task.Delay(TimeSpan.FromSeconds(3));

                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);

                string ID = hasUser.Id;


                var values = _teamService.TGetList().Where(x => x.studentID1 == ID || x.studentID2 == ID || x.studentID3 == ID).ToList().FirstOrDefault();
                if (values == null)
                {
                    return View(nameof(StudentAddTeam));
                }
                if (values != null)
                {
                    ViewBag.studentID1_V = values.studentID1;
                    ViewBag.studentID2_V = values.studentID2;
                    ViewBag.studentID3_V = values.studentID3;
                }
                else
                {
                    return RedirectToAction("StudentAddTeam");
                }


                var result = _mapper.Map<UpdateTeamModel>(values);

                return View(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudentProject(Team p, int id)
        {
            try
            {
                await GetDropList();
                if (p.projectChoice1 == p.projectChoice2 || p.projectChoice1 == p.projectChoice3 || p.projectChoice1 == p.projectChoice4 || p.projectChoice1 == p.projectChoice5 || p.projectChoice1 == p.projectChoice6 || p.projectChoice1 == p.projectChoice7 || p.projectChoice1 == p.projectChoice8 || p.projectChoice1 == p.projectChoice9 || p.projectChoice1 == p.projectChoice10)
                {
                    TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                    return View();
                }
                else if (p.projectChoice2 == p.projectChoice1 || p.projectChoice2 == p.projectChoice3 || p.projectChoice2 == p.projectChoice4 || p.projectChoice2 == p.projectChoice5 || p.projectChoice2 == p.projectChoice6 || p.projectChoice2 == p.projectChoice7 || p.projectChoice2 == p.projectChoice8 || p.projectChoice2 == p.projectChoice9 || p.projectChoice2 == p.projectChoice10)
                {
                    TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                    return View();
                }
                else if (p.projectChoice3 == p.projectChoice1 || p.projectChoice3 == p.projectChoice2 || p.projectChoice3 == p.projectChoice4 || p.projectChoice3 == p.projectChoice5 || p.projectChoice3 == p.projectChoice6 || p.projectChoice3 == p.projectChoice7 || p.projectChoice3 == p.projectChoice8 || p.projectChoice3 == p.projectChoice9 || p.projectChoice3 == p.projectChoice10)
                {
                    TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                    return View();
                }
                else if (p.projectChoice4 == p.projectChoice1 || p.projectChoice4 == p.projectChoice2 || p.projectChoice4 == p.projectChoice3 || p.projectChoice4 == p.projectChoice5 || p.projectChoice4 == p.projectChoice6 || p.projectChoice4 == p.projectChoice7 || p.projectChoice4 == p.projectChoice8 || p.projectChoice4 == p.projectChoice9 || p.projectChoice4 == p.projectChoice10)
                {
                    TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                    return View();
                }
                else if (p.projectChoice5 == p.projectChoice1 || p.projectChoice5 == p.projectChoice2 || p.projectChoice5 == p.projectChoice3 || p.projectChoice5 == p.projectChoice4 || p.projectChoice5 == p.projectChoice6 || p.projectChoice5 == p.projectChoice7 || p.projectChoice5 == p.projectChoice8 || p.projectChoice5 == p.projectChoice9 || p.projectChoice5 == p.projectChoice10)
                {
                    TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                    return View();
                }
                else if (p.projectChoice6 == p.projectChoice1 || p.projectChoice6 == p.projectChoice2 || p.projectChoice6 == p.projectChoice3 || p.projectChoice6 == p.projectChoice4 || p.projectChoice6 == p.projectChoice5 || p.projectChoice6 == p.projectChoice7 || p.projectChoice6 == p.projectChoice8 || p.projectChoice6 == p.projectChoice9 || p.projectChoice6 == p.projectChoice10)
                {
                    TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                    return View();
                }
                else if (p.projectChoice7 == p.projectChoice1 || p.projectChoice7 == p.projectChoice2 || p.projectChoice7 == p.projectChoice3 || p.projectChoice7 == p.projectChoice4 || p.projectChoice7 == p.projectChoice5 || p.projectChoice7 == p.projectChoice6 || p.projectChoice7 == p.projectChoice8 || p.projectChoice7 == p.projectChoice9 || p.projectChoice7 == p.projectChoice10)
                {
                    TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                    return View();
                }
                else if (p.projectChoice8 == p.projectChoice1 || p.projectChoice8 == p.projectChoice2 || p.projectChoice8 == p.projectChoice3 || p.projectChoice8 == p.projectChoice4 || p.projectChoice8 == p.projectChoice5 || p.projectChoice8 == p.projectChoice6 || p.projectChoice8 == p.projectChoice7 || p.projectChoice8 == p.projectChoice9 || p.projectChoice8 == p.projectChoice10)
                {
                    TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                    return View();
                }

                else if (p.projectChoice9 == p.projectChoice1 || p.projectChoice9 == p.projectChoice2 || p.projectChoice9 == p.projectChoice3 || p.projectChoice9 == p.projectChoice4 || p.projectChoice9 == p.projectChoice5 || p.projectChoice9 == p.projectChoice6 || p.projectChoice9 == p.projectChoice7 || p.projectChoice9 == p.projectChoice8 || p.projectChoice9 == p.projectChoice10)
                {
                    TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                    return View();
                }

                else if (p.projectChoice10 == p.projectChoice1 || p.projectChoice10 == p.projectChoice2 || p.projectChoice10 == p.projectChoice3 || p.projectChoice10 == p.projectChoice4 || p.projectChoice10 == p.projectChoice5 || p.projectChoice10 == p.projectChoice6 || p.projectChoice10 == p.projectChoice7 || p.projectChoice10 == p.projectChoice9 || p.projectChoice10 == p.projectChoice9)
                {
                    TempData["SuccessMessage"] = "The same project cannot be selected more than once!";
                    return View();
                }
                else
                {
                  
                    string userName = User.Identity.Name;
                    var hasUser = await _UserManager.FindByNameAsync(userName);


                    TeamValidator bcv = new TeamValidator();
                    ValidationResult result = bcv.Validate(p);
                    if (result.IsValid)
                    {
                        //  var value = _teamService.TGetById(id);
                        string ID = hasUser.Id;


                        var value = _teamService.TGetList().Where(x => x.studentID1 == ID || x.studentID2 == ID || x.studentID3 == ID).ToList().FirstOrDefault();

                        p.Team_ID = value.Team_ID;
                        p.Team_Name = value.Team_Name;
                        p.AssignedProjectID = 0;
                        p.Department_ID = value.Department_ID;
                        p.Team_Capacity = value.Team_Capacity;
                        p.Team_Description = value.Team_Description;

                        p.projectChoice1 = p.projectChoice1;
                        p.projectChoice2 = p.projectChoice2;
                        p.projectChoice3 = p.projectChoice3;
                        p.projectChoice4 = p.projectChoice4;
                        p.projectChoice5 = p.projectChoice5;
                        p.projectChoice6 = p.projectChoice6;
                        p.projectChoice7 = p.projectChoice7;
                        p.projectChoice8 = p.projectChoice8;
                        p.projectChoice9 = p.projectChoice9;
                        p.projectChoice10 = p.projectChoice10;

                        p.studentID1 = value.studentID1;
                        p.studentID2 = value.studentID2;
                        p.studentID3 = value.studentID3;

                        p.Create_ID = value.Create_ID;
                        p.Create_Date = value.Create_Date;
                        p.Update_ID = hasUser.Id;
                        p.Update_Date = DateTime.Now;

                        p.IsDelete = value.IsDelete;
                        p.IsDelete_ID = value.IsDelete_ID;
                        p.IsDelete_Date = value.IsDelete_Date;
                        p.IsActive = p.IsActive;


                        _teamService.TUpdate(p);

                        return RedirectToAction(nameof(StudentIndex));
                    } 
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                            return View();
                        }
                    }
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> StudentAddTeam()
        {
            await GetDropList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StudentAddTeam(Team p)
        {
            try
            {
                await GetDropList();


                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);
                var userID = hasUser.Id;
                var user = await _UserManager.FindByIdAsync(userID);
                var roles = await _UserManager.GetRolesAsync(user);
                var getRole = roles.FirstOrDefault();


                TeamValidator bcv = new TeamValidator();
                ValidationResult result = bcv.Validate(p);
                if (result.IsValid)
                {
                    p.Team_Name = p.Team_Name;
                    p.AssignedProjectID = 0;
                    p.Department_ID = p.Department_ID;
                    p.Team_Capacity = p.Team_Capacity;
                    p.Team_Description = p.Team_Description;

                    p.projectChoice1 = p.projectChoice1;
                    p.projectChoice2 = p.projectChoice2;
                    p.projectChoice3 = p.projectChoice3;
                    p.projectChoice4 = p.projectChoice4;
                    p.projectChoice5 = p.projectChoice5;
                    p.projectChoice6 = p.projectChoice6;
                    p.projectChoice7 = p.projectChoice7;
                    p.projectChoice8 = p.projectChoice8;
                    p.projectChoice9 = p.projectChoice9;
                    p.projectChoice10 = p.projectChoice10;

                    p.studentID1 = p.studentID1;
                    p.studentID2 = p.studentID2;
                    p.studentID3 = p.studentID3;



                    p.Create_ID = hasUser.Id;
                    p.Create_Date = DateTime.Now;
                    p.Update_ID = null;
                    p.Update_Date = DateTime.Now;

                    p.IsDelete = false;
                    p.IsDelete_ID = null;
                    p.IsDelete_Date = DateTime.Now;
                    p.IsActive = true;

                    _teamService.TAdd(p);
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        //hata mesajı ve log yaz
                    }
                    return View();
                }



                if (getRole == "AdminRole")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("StudentIndex");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }






        public async Task<IActionResult> AddTestData(Team p)
        {
            try
            {
                Random rastgele = new Random();
                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);
                var userID = hasUser.Id;
                var user = await _UserManager.FindByIdAsync(userID);
                var roles = await _UserManager.GetRolesAsync(user);
                var getRole = roles.FirstOrDefault();

                TeamValidator bcv = new TeamValidator();
                ValidationResult result = bcv.Validate(p);
                if (result.IsValid)
                {
                    string name = "Team_";
                    for (int i = 0; i < 500; i++)
                    {
                        int numbers = rastgele.Next(1, 11);
                        //       int[] randomNumbers = numbers.OrderBy(x => rastgele.Next()).Take(10).ToArray();

                        int Department_ID = rastgele.Next(1, 8);
                        int Team_Capacity = rastgele.Next(1, 4);

                        int uzunluk = 15;
                        string rasgeleString1 = "";
                        string rasgeleString2 = "";
                        string rasgeleString3 = "";
                        for (int j = 0; j < uzunluk; j++)
                        {
                            rasgeleString1 += (char)rastgele.Next(65, 91);
                            rasgeleString2 += (char)rastgele.Next(65, 91);
                            rasgeleString3 += (char)rastgele.Next(65, 91);
                        }

                        var randomNumbers1 = _projectService.TGetList().Where(x => x.IsActive == true).Where(x => x.Department_ID == numbers || x.DepartmentID2 == numbers || x.DepartmentID3 == numbers || x.DepartmentID4 == numbers).ToList();
                        int[] selectProID = randomNumbers1.Select(x => x.Project_ID).ToArray();
                        int[] selectProIDSelectID = selectProID.OrderBy(x => rastgele.Next()).Take(10).ToArray();



                        p.Team_Name = name + i;
                        p.AssignedProjectID = 0;


                        p.Department_ID = numbers;
                        p.Team_Capacity = Team_Capacity;
                        p.Team_Description = "Team_Description_" + i;

                        for (int e = 0; e < 11; e++)
                        {
                            p.projectChoice1 = selectProIDSelectID[0];
                            p.projectChoice2 = selectProIDSelectID[1];
                            p.projectChoice3 = selectProIDSelectID[2];
                            p.projectChoice4 = selectProIDSelectID[3];
                            p.projectChoice5 = selectProIDSelectID[4];
                            p.projectChoice6 = selectProIDSelectID[5];
                            p.projectChoice7 = selectProIDSelectID[6];
                            p.projectChoice8 = selectProIDSelectID[7];
                            p.projectChoice9 = selectProIDSelectID[8];
                            p.projectChoice10 = selectProIDSelectID[9];
                        }
                        if (Team_Capacity == 3)
                        {
                            p.studentID1 = rasgeleString1;
                            p.studentID2 = rasgeleString2;
                            p.studentID3 = rasgeleString3;
                        }
                        else if (Team_Capacity == 2)
                        {
                            p.studentID1 = rasgeleString1;
                            p.studentID2 = rasgeleString2;
                            p.studentID3 = null;
                        }
                        else
                        {
                            p.studentID1 = rasgeleString1;
                            p.studentID2 = null;
                            p.studentID3 = null;
                        }

                        p.Create_ID = hasUser.Id;
                        p.Create_Date = DateTime.Now;
                        p.Update_ID = null;
                        p.Update_Date = DateTime.Now;

                        p.IsDelete = false;
                        p.IsDelete_ID = null;
                        p.IsDelete_Date = DateTime.Now;
                        p.IsActive = true;
                        _teamService.TAdd(p);
                        p.Team_ID = 0;
                    }
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        //hata mesajı ve log yaz
                    }
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }








    }
}
