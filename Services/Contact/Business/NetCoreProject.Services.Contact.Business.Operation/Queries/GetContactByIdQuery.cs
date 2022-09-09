using AutoMapper;
using MediatR;
using NetCoreProject.Architecture.Data.Cache.Interfaces;
using NetCoreProject.Services.Contact.Model.Exchange.Contact.GetById;

namespace NetCoreProject.Services.Contact.Business.Operation.Queries;

public class GetContactByIdQuery : IRequestHandler<GetContactByIdRequestModel, GetContactByIdResponseModel>
{
    private readonly ICacheService _cacheService;
    private readonly IMapper _mapper;

    public GetContactByIdQuery(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    public Task<GetContactByIdResponseModel> Handle(GetContactByIdRequestModel request, CancellationToken cancellationToken)
    {
        var contact = _cacheService.GetByKey<Model.CacheModel.Contact>(request.Id.ToString());
        if (contact == default)
            throw new ArgumentNullException("Contact not found!");

        var contactResponseModel = _mapper.Map<GetContactByIdResponseModel>(contact);
        throw new NotImplementedException();
    }
}
