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

        [Authorize(Roles = "Admin")]
        public IActionResult RoleBase()
        {
            return View();
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult ClaimsBase()
        {
            return View();
        }
    }
}
