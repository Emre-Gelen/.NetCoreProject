namespace NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Get;

public class GetLessonMapModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Guid> ContactIds { get; set; }
}
