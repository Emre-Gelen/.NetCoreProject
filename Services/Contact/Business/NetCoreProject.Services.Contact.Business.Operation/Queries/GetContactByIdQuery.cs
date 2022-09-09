using AutoMapper;
using MediatR;
using NetCoreProject.Architecture.Data.Cache.Interfaces;
using NetCoreProject.Services.Contact.Model.Exchange.Contact.GetById;

namespace NetCoreProject.Services.Contact.Business.Operation.Queries;

public class GetContactByIdQuery : IRequestHandler<GetContactByIdRequestModel, GetContactByIdResponseModel>
{
    private readonly ICacheService _cacheService;
    private readonly IMapper _mapper;

    public GetContactByIdQuery(ICacheService cacheService, IMapper mapper)
    {
        _cacheService = cacheService;
        _mapper = mapper;
    }

    public async Task<GetContactByIdResponseModel> Handle(GetContactByIdRequestModel request, CancellationToken cancellationToken)
    {
        var contact = await _cacheService.GetByKey<Model.CacheModel.Contact>(request.Id.ToString());
        if (contact == default)
            throw new ArgumentNullException("Contact not found!");

        var contactResponseModel = _mapper.Map<GetContactByIdResponseModel>(contact);
        return contactResponseModel;
    }
}
