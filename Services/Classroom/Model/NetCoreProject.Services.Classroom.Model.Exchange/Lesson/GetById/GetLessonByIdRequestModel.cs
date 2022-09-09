using MediatR;

namespace NetCoreProject.Services.Classroom.Model.Exchange.Lesson.GetById;
public class GetLessonByIdRequestModel : IRequest<GetLessonByIdResponseModel>
{
    public Guid Id { get; set; }
}
