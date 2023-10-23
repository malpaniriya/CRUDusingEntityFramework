using CRUDusingEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDusingEntityFramework.Data
{
    //chlid class to get the featuress of Dbcontext class
    public class ApplicationDbContext:DbContext
    {
        //DbcontextOption is used for override the configuration---->connection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
