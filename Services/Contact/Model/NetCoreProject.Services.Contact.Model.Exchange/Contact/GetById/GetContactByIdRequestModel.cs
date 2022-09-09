using MediatR;
namespace NetCoreProject.Services.Contact.Model.Exchange.Contact.GetById;

public class GetContactByIdRequestModel : IRequest<GetContactByIdResponseModel>
{
    public Guid Id { get; set; }
}
