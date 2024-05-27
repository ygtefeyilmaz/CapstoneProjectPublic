using AutoMapper;
using BitirmeProjesiUI.Models.Project;
using BitirmeProjesiUI.Models.Result;
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
    public class ResultController : Controller
    {
        private readonly IResultService _resultService;
        private readonly UserManager<AppUser> _UserManager;
        private readonly IMapper _mapper;
        private readonly ITeamService _teamService  ;
        private readonly IProjectService _projectService;

        public ResultController(IResultService resultService, UserManager<AppUser> userManager, IMapper mapper, ITeamService teamService, IProjectService projectService)
        {
            _resultService = resultService;
            _UserManager = userManager;
            _mapper = mapper;
            _teamService = teamService;
            _projectService = projectService;
        }



        public IActionResult Index()
        {
            var value = _resultService.GetContactList();
            return View(value);
        }

        public async Task<IActionResult> StudentResultIndex()
        {
            string userName = User.Identity.Name;
            var hasUser = await _UserManager.FindByNameAsync(userName);
            var DepartmentID = hasUser.Department_ID;

            var value = _resultService.GetContactList().ToList();
            return View(value);
        }


        [HttpGet]
        public IActionResult AddResult()
        {
            GetDropList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddResult(Result p)
        {
            try
            {
                GetDropList();

                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);


                ResultValidator bcv = new ResultValidator();
                ValidationResult result = bcv.Validate(p);
                if (result.IsValid)
                {
                    p.Team_ID = p.Team_ID;
                    p.Project_ID = p.Project_ID;
                    
                    //p.Create_ID = hasUser.Id;
                    //p.Create_Date = DateTime.Now;
                    //p.Update_ID = null;
                    //p.Update_Date = DateTime.Now;

                    //p.IsDelete = false;
                    //p.IsDelete_ID = null;
                    //p.IsDelete_Date = DateTime.Now;
                    //p.IsActive = true;

                    _resultService.TAdd(p);
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
        public IActionResult UpdateResult(int id)
        {
            try
            {
                GetDropList();
                var values = _resultService.TGetById(id);
                var result = _mapper.Map<UpdateResultModel>(values);

                return View(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateResult(Result p, int id)
        {
            try
            {
                GetDropList();
                string userName = User.Identity.Name;
                var hasUser = await _UserManager.FindByNameAsync(userName);

                ResultValidator bcv = new ResultValidator();
                ValidationResult result = bcv.Validate(p);
                if (result.IsValid)
                {
                    var value = _resultService.TGetById(id);

                    p.Result_ID = id;
                    p.Team_ID = p.Team_ID;
                    p.Project_ID = p.Project_ID;


                    //p.Create_ID = value.Create_ID;
                    //p.Create_Date = value.Create_Date;
                    //p.Update_ID = hasUser.Id;
                    //p.Update_Date = DateTime.Now;

                    //p.IsDelete = value.IsDelete;
                    //p.IsDelete_ID = value.IsDelete_ID;
                    //p.IsDelete_Date = value.IsDelete_Date;
                    //p.IsActive = p.IsActive;


                    _resultService.TUpdate(p);

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
        public IActionResult DeleteResult(int id)
        {
            var value = _resultService.TGetById(id);
            _resultService.TDelete(value);

            return RedirectToAction("Index");
        }


        public IActionResult GetDropList()
        {
            List<SelectListItem> Team_Values = (from x in _teamService.TGetList().Where(x => x.IsActive == true)
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Team_Name,
                                                          Value = x.Team_ID.ToString()
                                                      }).ToList();
            ViewBag.Team_Values_V = Team_Values;

            List<SelectListItem> Project_Values = (from x in _projectService.TGetList().Where(x => x.IsActive == true)
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Project_Name,
                                                          Value = x.Project_ID.ToString()
                                                      }).ToList();
            ViewBag.Project_Values_V = Project_Values;

            return View();
        }
    }
}
