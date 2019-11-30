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
            builder = new DbContextOptionsBuilder<Kibol_AlertContext>().UseSqlServer("Server=tcp:kosa-czy-sztama.database.windows.net,1433;Initial Catalog=kosa-czy-sztama;Persist Security Info=False;User ID=kosa;Password=Qwer1234.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            options = builder.Options;
            Context = new Kibol_AlertContext(options);
        }
    }
}