using NetCoreProject.Services.Classroom.Model.Exchange.Contact._Common;

namespace NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Get;

public class GetLessonsResponseModel
{
    public string LessonName { get; set; }
    public List<ContactData> Contacts { get; set; }
}
