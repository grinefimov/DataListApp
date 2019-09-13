using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebApi.Models;

namespace WebApi
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Server=GRIN-PC\\SQLEXPRESS;Database=VueWebApp;Trusted_Connection=True;");

            return new DataContext(optionsBuilder.Options);
        }
    }
}