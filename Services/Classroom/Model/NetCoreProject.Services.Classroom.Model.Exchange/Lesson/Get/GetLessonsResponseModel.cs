using NetCoreProject.Services.Classroom.Model.Exchange.Contact._Common;

namespace NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Get;

public class GetLessonsResponseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<ContactData> Contacts { get; set; }
}
