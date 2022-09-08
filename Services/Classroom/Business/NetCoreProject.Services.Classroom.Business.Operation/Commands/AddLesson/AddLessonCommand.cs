using MediatR;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Add;

namespace NetCoreProject.Services.Classroom.Business.Operation.Commands.AddLesson;

public class AddLessonCommand : IRequestHandler<AddLessonRequestModel, AddLessonResponseModel>
{
    public Task<AddLessonResponseModel> Handle(AddLessonRequestModel request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new AddLessonResponseModel());
    }
}
