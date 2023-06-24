using BeSpoked.Db;
using DbSeeder.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Registering Services");
var services = GetServices();

Console.WriteLine("Seeding Products");
await services.GetRequiredService<SeedDb>().Run();

ServiceProvider GetServices()
{
    var services = new ServiceCollection();
    services.AddSqlite<BeSpokedDbContext>("ConnectionString");
    
    services.AddScoped<SeedDb>();
    return services.BuildServiceProvider();
}
