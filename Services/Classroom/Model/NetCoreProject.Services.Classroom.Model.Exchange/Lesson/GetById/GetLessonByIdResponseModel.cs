using NetCoreProject.Services.Classroom.Model.Exchange.Contact._Common;

namespace NetCoreProject.Services.Classroom.Model.Exchange.Lesson.GetById;
public class GetLessonByIdResponseModel
{
    public string Name { get; set; }
    public List<ContactData> Contacts { get; set; }
}
