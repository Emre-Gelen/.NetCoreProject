using AutoMapper;
using MediatR;
using NetCoreProject.Architecture.Data.Cache.Interfaces;
using NetCoreProject.Services.Contact.Model.Exchange.Contact.Add;

namespace NetCoreProject.Services.Contact.Business.Operation.Commands.AddContact;

public class AddContactCommand : IRequestHandler<AddContactRequestModel, AddContactResponseModel>
{
    private readonly ICacheService _cacheService;
    private readonly IMapper _mapper;

    public AddContactCommand(IMapper mapper, ICacheService cacheService)
    {
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<AddContactResponseModel> Handle(AddContactRequestModel request, CancellationToken cancellationToken)
    {
        var expirationTime = DateTimeOffset.Now.AddHours(1);
        var newContactGuid = Guid.NewGuid();
        var newContact = _mapper.Map<Model.CacheModel.Contact>(request);

        await _cacheService.SetData(newContactGuid.ToString(), newContact, expirationTime);

        AddContactResponseModel response = _mapper.Map<AddContactResponseModel>(newContact);
        response.Id = newContactGuid;

        return response;
    }
}
