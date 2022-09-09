using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetCoreProject.Services.Contact.Business.Mapper;
using NetCoreProject.Services.Contact.Business.Operation;
using NetCoreProject.Services.Contact.Data.ApplicationSetting.Manager;
using NetCoreProject.Services.Contact.Data.Interfaces;
using System.Reflection;

namespace NetCoreProject.Services.Contact.Registration;

public static class ContactRegistration
{
    public static IServiceCollection AddContactRegistration(this IServiceCollection services)
    {
        //var assemblyReferences = AppDomain.CurrentDomain.GetAssemblies();

        Assembly configurationAppAssembly = typeof(AssemblyReference).Assembly;
        Assembly mappingAssembly = typeof(MappingAssemblyReference).Assembly;

        services.AddScoped<IContactValidationConstantsStore, ContactValidationConstantsApplicationSettingManager>();

        services.AddMediatR(configurationAppAssembly);
        //services.AddMediatR(assemblyReferences);

        services.AddAutoMapper(mappingAssembly);

        services.AddValidatorsFromAssembly(configurationAppAssembly);
        //services.AddValidatorsFromAssemblies(assemblyReferences);
        services.AddFluentValidationAutoValidation();

        return services;
    }
}
