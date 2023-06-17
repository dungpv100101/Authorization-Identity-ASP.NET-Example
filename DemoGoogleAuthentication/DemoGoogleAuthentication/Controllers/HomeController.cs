using DemoGoogleAuthentication.Models;
using DemoGoogleAuthentication.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoGoogleAuthentication.Controllers
{
    [ApiController]
    [Route("/v1/api/[controller]/[action]")]
    public class HomeController : Controller
    {
        // Authentication with Google

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return Ok("Authenticated with Google account");
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetToken()
        {
            var accessToken = HttpContext.GetTokenAsync(GoogleDefaults.AuthenticationScheme, "access_token");
            return Ok(accessToken);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Ok("Logout");
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetData()  // GET method test authentication
        {
            return Ok("Get data successfully");
        }




        // Form Authentication with cookie
        [HttpPost]
        public IActionResult LoginCookie([FromForm] LoginRequest request)
        {
            var conf = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            // Check user name and password
            if (!conf["Account:email"].Equals(request.Email) || !conf["Account:password"].Equals(request.Password))
            {
                return Unauthorized();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, request.Email),
                new Claim("FullName", "FullName:"+request.Email)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {

            };

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return Ok("Authenticated with form data");
        }

        [HttpGet, HttpPost]
        public IActionResult LogutCookie()
        {

            // Clear the existing external cookie
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok("Logout");
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetCookieClaims()
        {
            var claims = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            return Ok(claims);
        }



        // Identity and JWT authentications

        /*private readonly IAuthenticationsRepository authentications;

        public HomeController(IAuthenticationsRepository repo)
        {
            authentications = repo;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest model)
        {
            var result = await authentications.SignUpAsync(model);
            if (result.Succeeded) { return Ok(result.Succeeded); }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] LoginRequest model)
        {
            var result = await authentications.SignInAsync(model);
            if (string.IsNullOrEmpty(result)) { return Unauthorized(); }
            return Ok(result);
        }*/
    }
}
