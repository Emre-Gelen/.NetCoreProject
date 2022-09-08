using MediatR;
namespace NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Delete;
public class DeleteLessonRequestModel : IRequest<bool>
{
    public Guid Id { get; set; }
}
