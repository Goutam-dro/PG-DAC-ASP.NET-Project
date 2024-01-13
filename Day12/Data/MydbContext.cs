using Day12.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Day12.Data
{
    public class MydbContext:IdentityDbContext<ApplicationUser>
    {
       public MydbContext(DbContextOptions<MydbContext> options) : base(options)
        {

        }   
        public DbSet<Student> Students { get; set; }

     }
}
