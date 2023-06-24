using BeSpoked.Api;
using BeSpoked.Api.Utilities;
using BeSpoked.Configuration;

var builder = WebApplication.CreateBuilder(args);

var buildConfiguration = BuildConfiguration.FromHostEnvironment(builder.Environment);
var localDev = buildConfiguration.IsLocalDev;

var services = builder.Services;
builder.Services.AddDomain(builder.Configuration);

services.AddControllers();

if (localDev) {
    services.AddReverseProxy().LoadSpaConfig();
}

var app = builder.Build();
app.UseServerResponseForExceptions();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

if (localDev) {
    app.MapReverseProxy();
} else {
    app.MapFallbackToFile("index.html");
}

app.Run();