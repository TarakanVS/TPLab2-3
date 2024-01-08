using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DbContextFactory : IDesignTimeDbContextFactory<Lab2Context>
    {
        public Lab2Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Lab2Context>();
            optionsBuilder.UseNpgsql("User ID=postgres; Password=Qq12345678; Server=localhost; Port=5432; Database=tplab2; Integrated Security=true; Pooling=true;");

            return new Lab2Context(optionsBuilder.Options);
        }
    }
}
