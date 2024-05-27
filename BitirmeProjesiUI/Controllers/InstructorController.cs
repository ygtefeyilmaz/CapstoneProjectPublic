using AutoMapper;
using BitirmeProjesiUI.Models.Instructor;
using BussinessLayer.Abstract;
using BussinessLayer.ValidaitonsRules;
using DataAccessLayer.Models;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesiUI.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorService _ınstructorService;
        private readonly UserManager<AppUser> _UserManager;
        private readonly IMapper _mapper;

        public InstructorController(IInstructorService ınstructorService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _ınstructorService = ınstructorService;
            _UserManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var value = _ınstructorService.TGetList();
            return View(value);
        }


        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddInstructor(Instructor p)
        {
            try
            {
                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);


                InstructorValidator bcv = new InstructorValidator();
                ValidationResult result = bcv.Validate(p);
                if (result.IsValid)
                {
                    p.Instructor_Name = p.Instructor_Name;
                    p.Instructor_Surname = p.Instructor_Surname;


                    p.Create_ID = hasUser.Id;
                    p.Create_Date = DateTime.Now;
                    p.Update_ID = null;
                    p.Update_Date = DateTime.Now;

                    p.IsDelete = false;
                    p.IsDelete_ID = null;
                    p.IsDelete_Date = DateTime.Now;
                    p.IsActive = true;

                    _ınstructorService.TAdd(p);
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
        public IActionResult UpdateInstructor(int id)
        {
            try
            {
                var values = _ınstructorService.TGetById(id);
                var result = _mapper.Map<UpdateInstructorModel>(values);

                return View(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateInstructor(Instructor p, int id)
        {
            try
            {
                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);

                InstructorValidator bcv = new InstructorValidator();
                ValidationResult result = bcv.Validate(p);
                if (result.IsValid)
                {
                    var value = _ınstructorService.TGetById(id);

                    p.Instructor_ID = id;
                    p.Instructor_Name = p.Instructor_Name;
                    p.Instructor_Surname = p.Instructor_Surname;


                    p.Create_ID = value.Create_ID;
                    p.Create_Date = value.Create_Date;
                    p.Update_ID = hasUser.Id;
                    p.Update_Date = DateTime.Now;

                    p.IsDelete = value.IsDelete;
                    p.IsDelete_ID = value.IsDelete_ID;
                    p.IsDelete_Date = value.IsDelete_Date;
                    p.IsActive = p.IsActive;


                    _ınstructorService.TUpdate(p);

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
        public IActionResult DeleteInstructor(int id)
        {
            var value = _ınstructorService.TGetById(id);
            _ınstructorService.TDelete(value);

            return RedirectToAction("Index");
        }
    }
}
