using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BeSpoked.Db;

public class BeSpokedDbContextBuilder: IDesignTimeDbContextFactory<BeSpokedDbContext>
{
    public BeSpokedDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BeSpokedDbContext>();
        optionsBuilder.UseSqlite("Data Source=sqlite.db");

        return new BeSpokedDbContext(optionsBuilder.Options);
    }
}