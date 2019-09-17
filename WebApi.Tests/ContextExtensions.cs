using WebApi.Models;

namespace WebApi.Tests
{
    public static class ContextExtensions
    {
        public static void Seed(this DataContext context)
        {
            context.DataItems.Add(new Data
            {
                Data1 = "1-1",
                Data2 = "1-2",
                Data3 = "1-3",
                Data4 = "1-4",
                Data5 = "1-5"
            });

            context.DataItems.Add(new Data
            {
                Data1 = "2-1",
                Data2 = "2-2",
                Data3 = "2-3",
                Data4 = "2-4",
                Data5 = "2-5"
            });

            context.SaveChanges();
        }
    }
}
