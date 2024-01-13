using Microsoft.EntityFrameworkCore;

namespace Day12.Data
{
    public class MydbContext:DbContext
    {
       public MydbContext(DbContextOptions<MydbContext> options) : base(options)
        {

        }   
        

     }
}
