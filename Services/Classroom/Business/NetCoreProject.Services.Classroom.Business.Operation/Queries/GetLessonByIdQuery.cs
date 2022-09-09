using AutoMapper;
using MediatR;
using NetCoreProject.Architecture.Data.Cache.Interfaces;
using NetCoreProject.Services.Classroom.Data.Interfaces;
using NetCoreProject.Services.Classroom.Model.CacheModel;
using NetCoreProject.Services.Classroom.Model.Exchange.Contact._Common;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.GetById;

namespace NetCoreProject.Services.Classroom.Business.Operation.Queries;

public class GetLessonByIdQuery : IRequestHandler<GetLessonByIdRequestModel, GetLessonByIdResponseModel>
{
    private readonly ICacheService _cacheService;
    private readonly IMapper _mapper;
    private readonly IContactDataStore _contactDataStore;

    public GetLessonByIdQuery(ICacheService cacheService, IMapper mapper, IContactDataStore contactDataStore)
    {
        _cacheService = cacheService;
        _mapper = mapper;
        _contactDataStore = contactDataStore;
    }
    public async Task<GetLessonByIdResponseModel> Handle(GetLessonByIdRequestModel request, CancellationToken cancellationToken)
    {
        var lesson = await _cacheService.GetByKey<Lesson>(request.Id.ToString());
        if (lesson == default)
            throw new ArgumentNullException("Lesson not found!");

        var lessonResponseModel = _mapper.Map<GetLessonByIdResponseModel>(lesson);
        if (lesson.ContactIds is not null)
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
        return lessonResponseModel;
    }
}
