using Microsoft.AspNetCore.Identity;

namespace Core3._1.ViewModel
{
    public class AddClaimViewModel
    {
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public IEnumerable<IdentityUser> Users { get; set; }
    }
}
