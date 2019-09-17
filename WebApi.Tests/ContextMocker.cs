using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Tests
{
    public class ContextMocker
    {
        public static DataContext GetDataContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;

            var context = new DataContext(options);

            context.Seed();

            return context;
        }
    }
}
