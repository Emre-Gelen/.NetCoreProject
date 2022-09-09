using MediatR;
using NetCoreProject.Architecture.Data.Cache.Interfaces;
using NetCoreProject.Services.Classroom.Data.Interfaces;
using NetCoreProject.Services.Classroom.Model.CacheModel;
using NetCoreProject.Services.Classroom.Model.Exchange.Contact._Common;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.AddStudent;

namespace NetCoreProject.Services.Classroom.Business.Operation.Commands.AddStudent;

public class AddStudentCommand : IRequestHandler<AddStudentRequestModel>
{
    private readonly IContactDataStore _contactDataStore;
    private readonly ICacheService _cacheService;

    public AddStudentCommand(IContactDataStore contactDataStore, ICacheService cacheService)
    {
        _contactDataStore = contactDataStore;
        _cacheService = cacheService;
    }

    public async Task<Unit> Handle(AddStudentRequestModel request, CancellationToken cancellationToken)
    {
        ContactData contact = await _contactDataStore.GetContact(request.ContactId);

        if (contact is null)
            throw new ArgumentNullException("Contact not found!");

        Lesson lesson = await _cacheService.GetByKey<Lesson>(request.LessonId.ToString());
        if (lesson == default)
            throw new ArgumentNullException("Lesson not found!");

        lesson.ContactIds = lesson.ContactIds ?? new List<Guid>();

        if (!lesson.ContactIds.Any(contact => contact == request.ContactId))
            lesson.ContactIds.Add(request.ContactId);

        var expirationTime = DateTimeOffset.Now.AddHours(1);
        await _cacheService.SetData(request.LessonId.ToString(), lesson, expirationTime);

        return await Task.FromResult(Unit.Value);
    }
}
