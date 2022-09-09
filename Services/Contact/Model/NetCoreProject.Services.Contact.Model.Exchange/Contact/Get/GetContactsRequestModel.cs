using MediatR;

namespace NetCoreProject.Services.Contact.Model.Exchange.Contact.Get;

public class GetContactsRequestModel : IRequest<IEnumerable<GetContactsResponseModel>>
{
    public string FilterPattern { get; set; }
}
