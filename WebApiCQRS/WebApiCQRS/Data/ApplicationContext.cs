using Microsoft.EntityFrameworkCore;
using WebApiCQRS.Data.EntitiesConfigration;
using WebApiCQRS.Models;

namespace WebApiCQRS.Data
{
    public class ApplicationContext : DbContext, IApplicationContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }


        // Specify DbSet properties etc
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add your own configuration here
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
       
      

        public DbSet<Product> Products { get; set; }

        public async Task<int> SaveChnages()
        {
            return await base.SaveChangesAsync();
        }
    }
}
