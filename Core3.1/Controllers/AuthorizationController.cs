using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core3._1.Controllers
{
    public class AuthorizationController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Employee")]
        public IActionResult RoleBase()
        {
            return View();
        }

        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult ClaimsBase()
        {
            return View();
        }

        [Authorize(Policy = "DevUser")]
        public IActionResult PolicyBase()
        {
            return View();
        }

        [Authorize(Policy = "canManageProduct")]
        public IActionResult PolicyRequirement()
        {
            return View();
        }
    }
}
