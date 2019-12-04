using Microsoft.EntityFrameworkCore;
using Kibol_Alert.Database;

namespace Kibol_Alert.Tests
{
    public class ContextBuilder
    {
        private readonly DbContextOptionsBuilder<Kibol_AlertContext> builder;
        private readonly DbContextOptions<Kibol_AlertContext> options;

        public Kibol_AlertContext Context { get; }

        public ContextBuilder()
        {
            builder = new DbContextOptionsBuilder<Kibol_AlertContext>().UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Kibol_Alert;Trusted_Connection=True;MultipleActiveResultSets=true");
            options = builder.Options;
            Context = new Kibol_AlertContext(options);
        }
    }
}