using DemoGoogleAuthentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoGoogleAuthentication.Repositories
{
    public interface IAuthenticationsRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpRequest model);
        public Task<string> SignInAsync(LoginRequest model);
    }
}
