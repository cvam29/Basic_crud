using Basic_crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Basic_crud.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
