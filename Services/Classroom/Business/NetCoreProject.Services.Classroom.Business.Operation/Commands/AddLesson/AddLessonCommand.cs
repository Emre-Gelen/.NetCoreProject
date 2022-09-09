using AutoMapper;
using MediatR;
using NetCoreProject.Architecture.Data.Cache.Interfaces;
using NetCoreProject.Services.Classroom.Model.CacheModel;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Add;

namespace NetCoreProject.Services.Classroom.Business.Operation.Commands.AddLesson;

public class AddLessonCommand : IRequestHandler<AddLessonRequestModel, AddLessonResponseModel>
{
    private readonly ICacheService _cacheService;
    private readonly IMapper _mapper;

    public AddLessonCommand(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    public async Task<AddLessonResponseModel> Handle(AddLessonRequestModel request, CancellationToken cancellationToken)
    {
        var expirationTime = DateTimeOffset.Now.AddHours(1);
        var newLessonGuid = Guid.NewGuid();
        var newLesson = _mapper.Map<Lesson>(request);
        await _cacheService.SetData(newLessonGuid.ToString(), newLesson, expirationTime);

        AddLessonResponseModel response = _mapper.Map<AddLessonResponseModel>(newLesson);
        response.Id = newLessonGuid;

        return response;
    }
}
