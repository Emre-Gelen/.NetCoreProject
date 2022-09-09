using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetCoreProject.Services.Classroom.Business.Mapper;
using NetCoreProject.Services.Classroom.Business.Operation;
using NetCoreProject.Services.Classroom.Data.Interfaces;
using NetCoreProject.Services.Classroom.Data.Services.Manager.ContactAPI;
using System.Reflection;
using NetCoreProject.Services.Classroom.Data.ApplicationSetting.Manager;

namespace NetCoreProject.Services.Classroom.Registration;

public static class ClassroomRegistration
{
    public static IServiceCollection AddClassroomRegistration(this IServiceCollection services)
    {
        //var assemblyReferences = AppDomain.CurrentDomain.GetAssemblies(); /*Assembly.GetExecutingAssembly();*/

        Assembly configurationAppAssembly = typeof(AssemblyReference).Assembly;
        Assembly mappingAssembly = typeof(MappingAssemblyReference).Assembly;

        services.AddScoped<ILessonValidationConstantsStore, LessonValidationConstantsApplicationSettingManager>();
        services.AddScoped<ILessonConstantsStore, LessonConstantsApplicationSettingManager>();


        services.AddMediatR(configurationAppAssembly);
        //services.AddMediatR(assemblyReferences);

        services.AddAutoMapper(mappingAssembly);

        services.AddValidatorsFromAssembly(configurationAppAssembly);
        //services.AddValidatorsFromAssemblies(assemblyReferences);
        services.AddFluentValidationAutoValidation();

        services.AddHttpClient();
        services.AddScoped<IContactDataStore, ContactServiceManager>();

        return services;
    }
}