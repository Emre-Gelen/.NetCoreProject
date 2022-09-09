using MediatR;

namespace NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Get;

public class GetLessonsRequestModel : IRequest<IEnumerable<GetLessonsResponseModel>>
{
    public string? FilterPattern { get; set; }
}
