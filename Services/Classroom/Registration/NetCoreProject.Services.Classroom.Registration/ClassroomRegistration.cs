using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetCoreProject.Services.Classroom.Business.Operation;
using NetCoreProject.Services.Classroom.Data.ApplicationSetting.Manager;
using NetCoreProject.Services.Classroom.Data.Interfaces;
using System.Reflection;

namespace NetCoreProject.Services.Classroom.Registration;

public static class ClassroomRegistration
{
    public static IServiceCollection AddClassroomRegistration(this IServiceCollection services)
    {
        var assemblyReferences = AppDomain.CurrentDomain.GetAssemblies(); /*Assembly.GetExecutingAssembly();*/

        Assembly configurationAppAssembly = typeof(AssemblyReference).Assembly;

        services.AddScoped<ILessonValidationConstantsStore, LessonValidationConstantsApplicationSettingManager>();
        services.AddScoped<ILessonConstantsStore, LessonConstantsApplicationSettingManager>();

        services.AddMediatR(configurationAppAssembly);
        services.AddMediatR(assemblyReferences);

        services.AddAutoMapper(assemblyReferences);

        services.AddValidatorsFromAssembly(configurationAppAssembly);
        services.AddValidatorsFromAssemblies(assemblyReferences);
        services.AddFluentValidationAutoValidation();

        return services;
    }
}