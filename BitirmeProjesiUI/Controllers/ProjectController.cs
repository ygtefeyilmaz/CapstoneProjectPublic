using AutoMapper;
using BitirmeProjesiUI.Models.Instructor;
using BitirmeProjesiUI.Models.Project;
using BussinessLayer.Abstract;
using BussinessLayer.ValidaitonsRules;
using DataAccessLayer.Models;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BitirmeProjesiUI.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly UserManager<AppUser> _UserManager;
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        private readonly IInstructorService _ınstructorService;

        public ProjectController(IProjectService projectService, UserManager<AppUser> userManager, IMapper mapper, IDepartmentService departmentService, IInstructorService ınstructorService)
        {
            _projectService = projectService;
            _UserManager = userManager;
            _mapper = mapper;
            _departmentService = departmentService;
            _ınstructorService = ınstructorService;
        }

        public async Task<IActionResult> Index()
        {
            var value = _projectService.GetContactList();
            return View(value);
        }

        public async Task<IActionResult> StudentIndex()
        {
            string userName = User.Identity.Name;
            var hasUser = await _UserManager.FindByNameAsync(userName);
            var DepartmentID = hasUser.Department_ID;


            var value = _projectService.GetContactList().Where(x => x.Department_ID == DepartmentID || x.DepartmentID2 == DepartmentID || x.DepartmentID3 == DepartmentID || x.DepartmentID4 == DepartmentID).ToList();


            return View(value);
        }


        [HttpGet]
        public IActionResult AddProject()
        {
            GetDropList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProject(Project p)
        {
            try
            {
                GetDropList();

                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);


                ProjectValidator bcv = new ProjectValidator();
                ValidationResult result = bcv.Validate(p);
                if (result.IsValid)
                {
                    p.Project_Name = p.Project_Name;
                    p.Department_ID = p.Department_ID;
                    p.DepartmentID2 = p.DepartmentID2;
                    p.Project_Description = p.Project_Description;
                    p.Instructor_ID = p.Instructor_ID;



                    p.Create_ID = hasUser.Id;
                    p.Create_Date = DateTime.Now;
                    p.Update_ID = null;
                    p.Update_Date = DateTime.Now;

                    p.IsDelete = false;
                    p.IsDelete_ID = null;
                    p.IsDelete_Date = DateTime.Now;
                    p.IsActive = true;

                    _projectService.TAdd(p);
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

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            try
            {
                GetDropList();
                var values = _projectService.TGetById(id);
                var result = _mapper.Map<UpdateProjectModel>(values);

                return View(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProject(Project p, int id)
        {
            try
            {
                GetDropList();
                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);

                ProjectValidator bcv = new ProjectValidator();
                ValidationResult result = bcv.Validate(p);
                if (result.IsValid)
                {
                    var value = _projectService.TGetById(id);

                    p.Project_ID = id;
                    p.Project_Name = p.Project_Name;
                    p.Department_ID = p.Department_ID;
                    p.DepartmentID2 = p.DepartmentID2;
                    p.Project_Description = p.Project_Description;
                    p.Instructor_ID = p.Instructor_ID;

                    p.Create_ID = value.Create_ID;
                    p.Create_Date = value.Create_Date;
                    p.Update_ID = hasUser.Id;
                    p.Update_Date = DateTime.Now;

                    p.IsDelete = value.IsDelete;
                    p.IsDelete_ID = value.IsDelete_ID;
                    p.IsDelete_Date = value.IsDelete_Date;
                    p.IsActive = p.IsActive;


                    _projectService.TUpdate(p);

                    return RedirectToAction("Index");
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
        public IActionResult DeleteProject(int id)
        {
            var value = _projectService.TGetById(id);
            _projectService.TDelete(value);

            return RedirectToAction("Index");
        }


        public IActionResult GetDropList()
        {
            List<SelectListItem> Department_Values = (from x in _departmentService.TGetList().Where(x => x.IsActive == true)
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Department_Name,
                                                          Value = x.Department_ID.ToString()
                                                      }).ToList();
            ViewBag.Department_Values_V = Department_Values;

            List<SelectListItem> Instructor_Values = (from x in _ınstructorService.TGetList().Where(x => x.IsActive == true)
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Instructor_Name + " " + x.Instructor_Surname,
                                                          Value = x.Instructor_ID.ToString()
                                                      }).ToList();
            ViewBag.Instructor_Values_V = Instructor_Values;

            return View();
        }

        [HttpGet]
        public IActionResult UpdateProjectDisabled(int id)
        {
            try
            {
                GetDropList();
                var values = _projectService.TGetById(id);
                var result = _mapper.Map<UpdateProjectModel>(values);

                return View(result);
            }
            catch (Exception)
            {

                throw;
            }
        }






        public async Task<IActionResult> AddTestData(Project p)
        {
            Random rastgele = new Random();
            string name = "Project_";
            for (int i = 0; i < 200; i++)
            {
                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);


                int[] Department_IDRandom = Enumerable.Range(1, 10).ToArray();
                int[] Department_Capasite = Enumerable.Range(1, 4).ToArray();
                int[] randomNumbers = Department_IDRandom.OrderBy(x => rastgele.Next()).Take(4).ToArray();

                /*
                 100 - 90 hepsi dolu olacak 
                 */
                p.Project_Name = name + i;

                p.Department_ID = randomNumbers[0];
                p.Department1_Capacity = 3;


                int randomSayi = rastgele.Next(1, 100);
                if (randomSayi >= 99)
                {
                    p.DepartmentID2 = randomNumbers[1];
                    p.DepartmentID3 = randomNumbers[2];
                    p.DepartmentID4 = randomNumbers[3];

                    p.Department2_Capacity = 3;
                    p.Department3_Capacity = 3;
                    p.Department4_Capacity = 3;
                }
                else if (randomSayi == 98)
                {
                    p.DepartmentID2 = 0;
                    p.DepartmentID3 = 0;
                    p.DepartmentID4 = 0;

                    p.Department2_Capacity = 0;
                    p.Department3_Capacity = 0;
                    p.Department4_Capacity = 0;
                }
                else if (randomSayi >= 90 && randomSayi < 98)
                {
                    p.DepartmentID2 = randomNumbers[1];
                    p.DepartmentID3 = randomNumbers[2];
                    p.DepartmentID4 = 0;

                    p.Department2_Capacity = 3;
                    p.Department3_Capacity = 3;
                    p.Department4_Capacity = 0;
                }
                else
                {
                    p.DepartmentID2 = randomNumbers[1];
                    p.DepartmentID3 = 0;
                    p.DepartmentID4 = 0;

                    p.Department2_Capacity = 3;
                    p.Department3_Capacity = 0;
                    p.Department4_Capacity = 0;
                }




                p.Instructor_ID = 1;
                p.Project_Description = name + i + " Description";





                p.Create_ID = hasUser.Id;
                p.Create_Date = DateTime.Now;
                p.Update_ID = null;
                p.Update_Date = DateTime.Now;

                p.IsDelete = false;
                p.IsDelete_ID = null;
                p.IsDelete_Date = DateTime.Now;
                p.IsActive = true;
                _projectService.TAdd(p);

                p.Project_ID = 0;

               
            }
            return View(p);
        }


         
}
}
