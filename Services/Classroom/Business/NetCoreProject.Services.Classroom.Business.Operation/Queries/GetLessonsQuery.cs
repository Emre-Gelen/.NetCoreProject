using AutoMapper;
using MediatR;
using NetCoreProject.Architecture.Data.Cache.Interfaces;
using NetCoreProject.Services.Classroom.Data.Interfaces;
using NetCoreProject.Services.Classroom.Model.CacheModel;
using NetCoreProject.Services.Classroom.Model.Exchange.Contact._Common;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Get;

namespace NetCoreProject.Services.Classroom.Business.Operation.Queries;

public class GetLessonsQuery : IRequestHandler<GetLessonsRequestModel, IEnumerable<GetLessonsResponseModel>>
{
    private readonly ICacheService _cacheService;
    private readonly IMapper _mapper;
    private readonly IContactDataStore _contactDataStore;

    public GetLessonsQuery(ICacheService cacheService, IMapper mapper, IContactDataStore contactDataStore)
    {
        _cacheService = cacheService;
        _mapper = mapper;
        _contactDataStore = contactDataStore;
    }

    public async Task<IEnumerable<GetLessonsResponseModel>> Handle(GetLessonsRequestModel request, CancellationToken cancellationToken)
    {
        var lessons = await _cacheService.GetAll<GetLessonMapModel>(request.FilterPattern);

        List<GetLessonsResponseModel> result = new();

        foreach (GetLessonMapModel lesson in lessons)
        {
            var lessonResponseModel = _mapper.Map<GetLessonsResponseModel>(lesson);
            if (lesson.ContactIds != null)
            {
                foreach (Guid contactId in lesson.ContactIds)
                {
                    ContactData contactData = await _contactDataStore.GetContact(contactId);

                    if (contactData is not null)
                    {
                        if (lessonResponseModel.Contacts is null)
                            lessonResponseModel.Contacts = new List<ContactData>();

                        lessonResponseModel.Contacts.Add(contactData);
                    }
                }
            }
            result.Add(lessonResponseModel);
        }
        return result;
    }
}
