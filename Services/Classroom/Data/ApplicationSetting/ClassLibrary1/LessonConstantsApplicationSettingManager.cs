using Microsoft.Extensions.Configuration;
using NetCoreProject.Architecture.Data.Configuration.ConfigurationManager;
using NetCoreProject.Services.Classroom.Common.Constants.Lesson;
using NetCoreProject.Services.Classroom.Data.Interfaces;

namespace NetCoreProject.Services.Classroom.Data.ApplicationSetting.Manager
{
    public class LessonConstantsApplicationSettingManager : ConfigurationManager, ILessonConstantsStore
    {
        public LessonConstantsApplicationSettingManager(IConfiguration configuration) : base(configuration) { }
        public string ContactAPIUrl => GetValue<string>(LessonConstants.ContactAPIUrl);
    }
}
