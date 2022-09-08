using MediatR;
namespace NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Add;
public class AddLessonRequestModel : IRequest<AddLessonResponseModel>
{
    public string Name { get; set; }
}
