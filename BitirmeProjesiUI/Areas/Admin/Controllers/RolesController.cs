using BitirmeProjesi.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentityApp.Web.Extenisons;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using Pit2mKurumsalWebSiteUI.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace BitirmeProjesi.Areas.Admin.Controllers
{
   // [Authorize(Roles = "admin, AdvancedRole")]
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RolesController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
      //  [Authorize(Roles = "AdvancedRole")]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.Select(x => new RoleViewModel()
            {
                Id = x.Id,
                Name = x.Name!
            }).ToListAsync();

            return View(roles);
        }

        // [Authorize(Roles = "admin, AdvancedRole")]
      //  [Authorize(Roles = "AdvancedRole")]
        public IActionResult RoleCreate()
        {
            return View();
        }


    //    [Authorize(Roles = "AdvancedRole")]
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleCreateViewModel request)
        {
            var result = await _roleManager.CreateAsync(new AppRole() { Name = request.Name });

            if (!result.Succeeded)
            {

                ModelState.AddModelErrorList(result.Errors);
                return View();
            }

            TempData["SuccessMessage"] = "Role created.";
            return RedirectToAction(nameof(RolesController.Index));

        }


    //    [Authorize(Roles = "AdvancedRole")]
        public async Task<IActionResult> RoleUpdate(string id)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(id);

            if (roleToUpdate == null)
            {
                throw new Exception("No role to update.");
            }


            return View(new RoleUpdateViewModel() { Id = roleToUpdate.Id, Name = roleToUpdate!.Name! });
        }

     //   [Authorize(Roles = "AdvancedRole")]
        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleUpdateViewModel request)
        {

            var roleToUpdate = await _roleManager.FindByIdAsync(request.Id);

            if (roleToUpdate == null)
            {
                throw new Exception("No role to update.");
            }

            roleToUpdate.Name = request.Name;

            await _roleManager.UpdateAsync(roleToUpdate);


            ViewData["SuccessMessage"] = "Role updated";

            return View();
        }

     //   [Authorize(Roles = "AdvancedRole")]
        public async Task<IActionResult> RoleDelete(string id)
        {
            var roleToDelete = await _roleManager.FindByIdAsync(id);

            if (roleToDelete == null)
            {
                throw new Exception("No role found to be deleted.");
            }

            var result = await _roleManager.DeleteAsync(roleToDelete);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.Select(x => x.Description).First());
            }

            TempData["SuccessMessage"] = "Role deleted";
            return RedirectToAction(nameof(RolesController.Index));




        }

     //   [Authorize(Roles = "AdvancedRole")]
        public async Task<IActionResult> AssignRoleToUser(string id)
        {
            var currentUser = (await _userManager.FindByIdAsync(id))!;
            ViewBag.userId = id;
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(currentUser);
            var roleViewModelList = new List<AssignRoleToUserViewModel>();

            foreach (var role in roles)
            {
                var assignRoleToUserViewModel = new AssignRoleToUserViewModel() { Id = role.Id, Name = role.Name! };

                if (userRoles.Contains(role.Name!))
                {
                    assignRoleToUserViewModel.Exist = true;
                }

                roleViewModelList.Add(assignRoleToUserViewModel);

            }
            return View(roleViewModelList);
        }
     //   [Authorize(Roles = "AdvancedRole")]
        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(string userId, List<AssignRoleToUserViewModel> requestList)
        {
            var userToAssignRoles = (await _userManager.FindByIdAsync(userId))!;
            foreach (var role in requestList)
            {
                if (role.Exist)
                {
                    await _userManager.AddToRoleAsync(userToAssignRoles, role.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(userToAssignRoles, role.Name);
                }
            }

            return RedirectToAction(nameof(HomeController.UserList), "Home");
        }
    }
}