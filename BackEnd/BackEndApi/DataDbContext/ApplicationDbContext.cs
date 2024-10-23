using BackEndApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.DataDbContext


{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }

        public DbSet<ContactVariables> ContactVariables { get; set; }
    }
}
