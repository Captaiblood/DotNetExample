using Microsoft.EntityFrameworkCore;
using WebApiCQRS.Models;

namespace WebApiCQRS.Data
{
    public class ApplicationContext : DbContext, IApplicationContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public async Task<int> SaveChnages()
        {
            return await base.SaveChangesAsync();
        }
    }
}
