using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiEFExample.Models;

namespace WebApiEFExample.Data
{
    public class ApplicationContext : DbContext, IApplicationContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public async Task<int> SaveChnages()
        {
            return await base.SaveChangesAsync();
        }
    }
}
