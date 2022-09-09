using MediatR;
using NetCoreProject.Architecture.Data.Cache.Interfaces;
using NetCoreProject.Services.Contact.Model.Exchange.Contact.Get;

namespace NetCoreProject.Services.Contact.Business.Operation.Queries;

public class GetContactsQuery : IRequestHandler<GetContactsRequestModel, IEnumerable<GetContactsResponseModel>>
{
    private readonly ICacheService _cacheService;

    public GetContactsQuery(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    public async Task<IEnumerable<GetContactsResponseModel>> Handle(GetContactsRequestModel request, CancellationToken cancellationToken)
    {
        var contacts = await _cacheService.GetAll<GetContactsResponseModel>(request.FilterPattern);
        return contacts;
    }
}
