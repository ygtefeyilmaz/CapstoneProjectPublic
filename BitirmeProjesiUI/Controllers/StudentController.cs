using AutoMapper;
using BitirmeProjesiUI.Models.Student;
using BussinessLayer.Abstract;
using BussinessLayer.ValidaitonsRules;
using DataAccessLayer.Models;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BitirmeProjesiUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService  _studentService;
        private readonly UserManager<AppUser> _UserManager;
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        private readonly ITeamService _teamService;

        public StudentController(IStudentService studentService, UserManager<AppUser> userManager, IMapper mapper, IDepartmentService departmentService, ITeamService teamService)
        {
            _studentService = studentService;
            _UserManager = userManager;
            _mapper = mapper;
            _departmentService = departmentService;
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var value = _studentService.TGetList();
            return View(value);
        }
         
        [HttpGet]
        public IActionResult AddStudent()
        {
            GetDropList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student p)
        {
            try
            {
                GetDropList();

                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);
                 
                StudentValidator bcv = new StudentValidator();
                ValidationResult result = bcv.Validate(p);
                if (result.IsValid)
                {
                    p.Student_Name = p.Student_Name;
                    p.Student_SurName = p.Student_SurName;
                    p.Department_ID = p.Department_ID;
                    p.Team_ID = 1;
                    

                    p.Create_ID = hasUser.Id;
                    p.Create_Date = DateTime.Now;
                    p.Update_ID = null;
                    p.Update_Date = DateTime.Now;

                    p.IsDelete = false;
                    p.IsDelete_ID = null;
                    p.IsDelete_Date = DateTime.Now;
                    p.IsActive = true;

                    _studentService.TAdd(p);
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
        public IActionResult UpdateStudent(int id)
        {
            try
            {
                GetDropList();
                var values = _studentService.TGetById(id);
                var result = _mapper.Map<UpdateStudentModel>(values);

                return View(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStudent(Student p, int id)
        {
            try
            {
                GetDropList();
                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);

                StudentValidator bcv = new StudentValidator();
                ValidationResult result = bcv.Validate(p);
                if (result.IsValid)
                {
                    var value = _studentService.TGetById(id);

                    p.Student_ID = id;
                    p.Student_Name = p.Student_Name;
                    p.Student_SurName = p.Student_SurName;
                    p.Department_ID = p.Department_ID;
                    p.Team_ID = p.Team_ID;
                     
                    p.Create_ID = value.Create_ID;
                    p.Create_Date = value.Create_Date;
                    p.Update_ID = hasUser.Id;
                    p.Update_Date = DateTime.Now;

                    p.IsDelete = value.IsDelete;
                    p.IsDelete_ID = value.IsDelete_ID;
                    p.IsDelete_Date = value.IsDelete_Date;
                    p.IsActive = p.IsActive;


                    _studentService.TUpdate(p);

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
        public IActionResult DeleteStudent(int id)
        {
            var value = _studentService.TGetById(id);
            _studentService.TDelete(value);

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

            List<SelectListItem> Team_Values = (from x in _teamService.TGetList().Where(x => x.IsActive == true)
                                                select new SelectListItem
                                                      {
                                                          Text = x.Team_Name,
                                                          Value = x.Team_ID.ToString()
                                                      }).ToList();
            ViewBag.Team_Values_V = Team_Values;

            return View();
        }


    }
}
