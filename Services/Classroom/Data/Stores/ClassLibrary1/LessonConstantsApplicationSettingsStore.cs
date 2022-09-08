using Microsoft.Extensions.Configuration;
using NetCoreProject.Architecture.Data.Configuration.ConfigurationManager;
using NetCoreProject.Services.Classroom.Data.Constants.LessonConstants;
using NetCoreProject.Services.Classroom.Data.Interfaces;

namespace NetCoreProject.Services.Classroom.Data.Stores.ApplicationSettingsStore;

public class LessonConstantsApplicationSettingsStore : ConfigurationManager, ILessonValidationConstants
{
    public LessonConstantsApplicationSettingsStore(IConfiguration configuration) : base(configuration) { }

    public int MinNameLength { get { return base.GetValue<int>(LessonValidationConstants.MinNameLength); } }
}
