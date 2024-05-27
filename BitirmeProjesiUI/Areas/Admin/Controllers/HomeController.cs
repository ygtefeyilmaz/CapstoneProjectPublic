using BitirmeProjesi.Areas.Admin.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer.Concrete;
using System.Security.Claims;
using BussinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;
using BitirmeProjesiUI.Models.Graph;

namespace BitirmeProjesi.Areas.Admin.Controllers
{
    // [Authorize(Roles = "admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IGraphService _graphService;

        public HomeController(UserManager<AppUser> userManager, IGraphService graphService)
        {
            _userManager = userManager;
            _graphService = graphService;
        }

        public IActionResult Index()
        {
          
            return View();
        }

        public async Task<IActionResult> UserList()
        {
            var userList = await _userManager.Users.ToListAsync();

            var userViewModelList = userList.Select(x => new UserViewModel()
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.UserName,
                IsActive = x.IsActive,
            }).ToList();

            return View(userViewModelList);
        }



        public IActionResult GraphChart()
        {

            var list = (from x in _graphService.TGetList() 


                        group x by new
                        {
                            x.Graph_ID,
                            x.NullProject,
                            x.z1,
                            x.z2,
                            x.z3,
                            x.z4,
                            x.z5,
                            x.z6,
                            x.z7,
                            x.z8,
                            x.z9,
                            x.z10,
                            x.z11,
                        

                        } into g
                        select new
                        {
                            NullProject = g.Key.NullProject, 
                            z1 = g.Key.z1,
                            z2 = g.Key.z2,
                            z3 = g.Key.z3,
                            z4 = g.Key.z4,
                            z5 = g.Key.z5,
                            z6 = g.Key.z6,
                            z7 = g.Key.z7,
                            z8 = g.Key.z8,
                            z9 = g.Key.z9,
                            z10 = g.Key.z10,
                            z11 = g.Key.z11,
                 

                        }).ToList();



            return Json(new { Jsonlist = list });
        }

    }
}