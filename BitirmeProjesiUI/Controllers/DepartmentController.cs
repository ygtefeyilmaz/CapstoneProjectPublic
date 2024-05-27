using AutoMapper;
using BitirmeProjesiUI.Models.Department;
using BussinessLayer.Abstract;
using BussinessLayer.ValidaitonsRules;
using DataAccessLayer.Models;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesiUI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly UserManager<AppUser> _UserManager;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _departmentService = departmentService;
            _UserManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()  
        {
            var value = _departmentService.TGetList();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department p)
        {
            try
            {
                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);


                DepartmentValidator bcv = new DepartmentValidator();
                ValidationResult result = bcv.Validate(p);
                if (result.IsValid)
                {
                    p.Department_Name = p.Department_Name;


                    p.Create_ID = hasUser.Id;
                    p.Create_Date = DateTime.Now;
                    p.Update_ID = null;
                    p.Update_Date = DateTime.Now;

                    p.IsDelete = false;
                    p.IsDelete_ID = null;
                    p.IsDelete_Date = DateTime.Now;
                    p.IsActive = true;

                    _departmentService.TAdd(p);
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
        public IActionResult UpdateDepartment(int id) 
        {
            try
            {
                var values = _departmentService.TGetById(id);
                var result = _mapper.Map<UpdateDepartmentModel>(values);

                return View(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(Department p, int id)
        {
            try
            {
                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);

                DepartmentValidator bcv = new DepartmentValidator();
                ValidationResult result = bcv.Validate(p);
                if (result.IsValid)
                {
                    var value = _departmentService.TGetById(id);

                    p.Department_ID = id;

                    p.Department_Name = p.Department_Name;


                    p.Create_ID = value.Create_ID;
                    p.Create_Date = value.Create_Date;
                    p.Update_ID = hasUser.Id;
                    p.Update_Date = DateTime.Now;

                    p.IsDelete = value.IsDelete;
                    p.IsDelete_ID = value.IsDelete_ID;
                    p.IsDelete_Date = value.IsDelete_Date;
                    p.IsActive = p.IsActive;


                    _departmentService.TUpdate(p);

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
        public IActionResult DeleteDepartment(int id)
        {
            var value = _departmentService.TGetById(id);
            _departmentService.TDelete(value);

            return RedirectToAction("Index");
        }

         
    }
}
