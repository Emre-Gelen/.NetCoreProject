using AutoMapper;
using NetCoreProject.Services.Classroom.Data.Services.Model.ContactAPI.Get;
using NetCoreProject.Services.Classroom.Model.CacheModel;
using NetCoreProject.Services.Classroom.Model.Exchange.Contact._Common;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Add;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Get;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.GetById;

namespace NetCoreProject.Services.Classroom.Business.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<GetContactResponseModel, ContactData>();
        CreateMap<AddLessonRequestModel, Lesson>();
        CreateMap<Lesson, AddLessonResponseModel>();
        CreateMap<Lesson, GetLessonByIdResponseModel>();

        CreateMap<GetLessonMapModel, GetLessonsResponseModel>();
    }
}