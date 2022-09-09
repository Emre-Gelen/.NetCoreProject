using AutoMapper;
using NetCoreProject.Services.Contact.Model.Exchange.Contact.Add;
using NetCoreProject.Services.Contact.Model.Exchange.Contact.GetById;

namespace NetCoreProject.Services.Contact.Business.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddContactRequestModel, Model.CacheModel.Contact>();
        CreateMap<Model.CacheModel.Contact, AddContactResponseModel>();

        CreateMap<Model.CacheModel.Contact, GetContactByIdResponseModel>();
    }
}
