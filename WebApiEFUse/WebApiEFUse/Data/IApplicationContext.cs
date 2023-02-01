using Microsoft.EntityFrameworkCore;
using WebApiEFExample.Models;

namespace WebApiEFExample.Data
{
    public interface IApplicationContext
    {
        DbSet<Student> Students { get; set; }

        Task<int> SaveChnages();
    }
}