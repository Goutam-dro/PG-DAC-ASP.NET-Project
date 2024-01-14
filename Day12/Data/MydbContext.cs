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
        public DbSet<AddProducts> AddProducts { get; set; }
        public DbSet<BuyProduct> BuyProducts { get; set; }
        public DbSet<ApproveList> ApproveLists { get; set; }

        public DbSet<Feedback1> Feedback1s { get; set; }


    }
}
