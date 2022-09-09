using MediatR;

namespace NetCoreProject.Services.Contact.Model.Exchange.Contact.Add
{
    public class AddContactRequestModel : IRequest<AddContactResponseModel>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
