namespace BeSpoked.Api;

public sealed record BuildConfiguration(BuildConfiguration.Environment Env)
{
    public bool IsDevelopment => Env is Environment.Development or Environment.LocalDev;
    public bool IsLocal => Env is Environment.LocalProd or Environment.LocalDev;
    public bool IsLocalDev => Env is Environment.LocalDev;

    public enum Environment
    {
        LocalDev,
        Development,
        LocalProd,
        Production
    }

    public static BuildConfiguration FromHostEnvironment(IHostEnvironment hostEnvironment)
    {
        var localDev = System.Environment.GetEnvironmentVariable("LocalDev") == "true";
        var env = hostEnvironment.EnvironmentName switch
        {
            "Development" when localDev => Environment.LocalDev,
            "Development" => Environment.Development,
            "Production" when localDev => Environment.LocalProd,
            "Production" => Environment.Production,
            _ => throw new Exception("Invalid environment")
        };
        return new BuildConfiguration(env);
    }
}