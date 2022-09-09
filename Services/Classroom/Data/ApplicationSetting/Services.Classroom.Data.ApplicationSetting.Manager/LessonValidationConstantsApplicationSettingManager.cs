using Microsoft.Extensions.Configuration;
using NetCoreProject.Architecture.Data.Configuration.ConfigurationManager;
using NetCoreProject.Services.Classroom.Common.Constants.Lesson;
using NetCoreProject.Services.Classroom.Data.Interfaces;

namespace NetCoreProject.Services.Classroom.Data.ApplicationSetting.Manager;

public class LessonValidationConstantsApplicationSettingManager : ConfigurationManager, ILessonValidationConstantsStore
{
    public LessonValidationConstantsApplicationSettingManager(IConfiguration configuration) : base(configuration) { }

    public int MinNameLength => GetValue<int>(LessonValidationConstants.MinNameLength);
}