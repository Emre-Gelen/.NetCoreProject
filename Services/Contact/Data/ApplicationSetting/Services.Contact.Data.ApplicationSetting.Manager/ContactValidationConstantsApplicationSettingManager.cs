using Microsoft.Extensions.Configuration;
using NetCoreProject.Architecture.Data.Configuration.ConfigurationManager;
using NetCoreProject.Services.Contact.Common.Constants.Contact;
using NetCoreProject.Services.Contact.Data.Interfaces;

namespace NetCoreProject.Services.Contact.Data.ApplicationSetting.Manager;

public class ContactValidationConstantsApplicationSettingManager : ConfigurationManager, IContactValidationConstantsStore
{
    public ContactValidationConstantsApplicationSettingManager(IConfiguration configuration) : base(configuration) { }

    public string SpecialCharacters => GetValue<string>(ContactValidationConstants.SpecialCharacters);

    public int MinAge => GetValue<int>(ContactValidationConstants.MinAge);

    public int MaxAge => GetValue<int>(ContactValidationConstants.MaxAge);
}