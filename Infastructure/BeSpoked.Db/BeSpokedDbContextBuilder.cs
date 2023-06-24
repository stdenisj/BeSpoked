using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BeSpoked.Db;

public class BeSpokedDbContextBuilder: IDesignTimeDbContextFactory<BeSpokedDbContext>
{
    public BeSpokedDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BeSpokedDbContext>();
        optionsBuilder.UseSqlite("ConnectionString");

        return new BeSpokedDbContext(optionsBuilder.Options);
    }
}