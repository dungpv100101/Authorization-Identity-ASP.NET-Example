using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Core3._1.ViewModel
{
    public class ViewRolesAndClaimsViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
