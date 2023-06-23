using BeSpoked.Db;
using DbSeeder.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Registering Services");
var services = GetServices();

Console.WriteLine("Seeding Products");
await services.GetRequiredService<SeedProducts>().Run();

ServiceProvider GetServices()
{
    var services = new ServiceCollection();

    services.AddDbContext<BeSpokedDbContext>(options =>
    {
        options.UseSqlite("Data Source=../BeSpoked.Db/sqlite.db");
    });
    services.AddScoped<SeedProducts>();
    return services.BuildServiceProvider();
}
