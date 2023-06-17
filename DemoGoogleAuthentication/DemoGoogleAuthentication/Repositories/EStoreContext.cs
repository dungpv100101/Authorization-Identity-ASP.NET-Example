using DemoGoogleAuthentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoGoogleAuthentication.Repositories
{
    public class EStoreContext : IdentityDbContext<ApplicationUser>
    {
        public EStoreContext(DbContextOptions<EStoreContext> options) : base(options) { }
    }
}
