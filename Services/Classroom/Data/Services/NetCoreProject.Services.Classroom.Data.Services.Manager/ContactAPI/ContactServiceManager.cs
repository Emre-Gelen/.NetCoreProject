using AutoMapper;
using NetCoreProject.Services.Classroom.Data.Interfaces;
using NetCoreProject.Services.Classroom.Data.Services.Model.ContactAPI.Get;
using NetCoreProject.Services.Classroom.Model.Exchange.Contact._Common;
using Newtonsoft.Json;

namespace NetCoreProject.Services.Classroom.Data.Services.Manager.ContactAPI;

public class ContactServiceManager : IContactDataStore
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILessonConstantsStore _lessonConstantsStore;
    private readonly IMapper _mapper;

    public ContactServiceManager(IHttpClientFactory httpClientFactory, ILessonConstantsStore store)
    {
        _httpClientFactory = httpClientFactory;
        _lessonConstantsStore = store;
    }

    public async Task<ContactData> GetContact(Guid contactId)
    {
        var contactHttpMessage = new HttpRequestMessage(
                       HttpMethod.Get,
                       $"{_lessonConstantsStore.ContactAPIUrl}{contactId}");

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(contactHttpMessage);

        var contactString = await httpResponseMessage.Content.ReadAsStringAsync();
        var contactModel = JsonConvert.DeserializeObject<GetContactResponseModel>(contactString);

        var contactData = _mapper.Map<ContactData>(contactModel);
        contactData.Id = contactId;
        return contactData;
    }
}
