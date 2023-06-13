using Core3._1.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Core3._1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole()
        {
            var users = _userManager.Users.ToList();
            var model = new AssignRoleViewModel
            {
                Users = users,
                Roles = _roleManager.Roles.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(AssignRoleViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(model.RoleId);

            if (role == null)
            {
                return NotFound();
            }

            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home"); // Chuyển hướng đến trang chủ hoặc trang khác
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            model.Roles = _roleManager.Roles;

            return View(model);
        }

        [HttpGet]
        public IActionResult AddClaim()
        {
            var users = _userManager.Users.ToList();
            var model = new AddClaimViewModel
            {
                Users = users
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddClaim(AddClaimViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                return NotFound();
            }

            var claim = new Claim(model.ClaimType, model.ClaimValue);
            var result = await _userManager.AddClaimAsync(user, claim);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            model.Users = _userManager.Users.ToList();

            return View(model);
        }
    }
}
