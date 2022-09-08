using Microsoft.Extensions.Configuration;

namespace NetCoreProject.Architecture.Data.Configuration.ConfigurationManager;

public abstract class ConfigurationManager
{
    private readonly IConfiguration Configuration;

    public ConfigurationManager(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }

    protected T GetValue<T>(string key)
    {
        return (T)Convert.ChangeType(this.Configuration[key], typeof(T));
    }
}
