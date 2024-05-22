using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationAgency.Models;

namespace WebApplicationAgency.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
      public   DbSet<Portfolies>Portfolies { get; set; }
    }
    
}
