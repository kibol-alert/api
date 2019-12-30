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
            builder = new DbContextOptionsBuilder<Kibol_AlertContext>().UseInMemoryDatabase(databaseName: "Add_writes_to_database");
            options = builder.Options;
            Context = new Kibol_AlertContext(options);
        }
    }
}