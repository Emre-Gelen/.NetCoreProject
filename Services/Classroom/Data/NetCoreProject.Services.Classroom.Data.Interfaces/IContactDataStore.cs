using NetCoreProject.Services.Classroom.Model.Exchange.Contact._Common;

namespace NetCoreProject.Services.Classroom.Data.Interfaces
{
    public interface IContactDataStore
    {
        Task<ContactData> GetContact(Guid contactId);
    }
}
