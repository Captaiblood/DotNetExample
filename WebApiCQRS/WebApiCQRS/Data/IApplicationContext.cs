using Microsoft.EntityFrameworkCore;
using WebApiCQRS.Models;

namespace WebApiCQRS.Data
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChnages();
    }
}