#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Contact/Web/NetCoreProject.Services.Contact.Web/NetCoreProject.Services.Contact.Web.API.csproj", "Services/Contact/Web/NetCoreProject.Services.Contact.Web/"]
COPY ["Architecture/Registration/NetCoreProject.Architecture.Registration.Redis/NetCoreProject.Architecture.Registration.Redis.csproj", "Architecture/Registration/NetCoreProject.Architecture.Registration.Redis/"]
COPY ["Architecture/Data/Cache/NetCoreProject.Architecture.Data.Cache.Interfaces/NetCoreProject.Architecture.Data.Cache.Interfaces.csproj", "Architecture/Data/Cache/NetCoreProject.Architecture.Data.Cache.Interfaces/"]
COPY ["Architecture/Data/Cache/Redis/NetCoreProject.Architecture.Data.Cache.Redis/NetCoreProject.Architecture.Data.Cache.Redis.csproj", "Architecture/Data/Cache/Redis/NetCoreProject.Architecture.Data.Cache.Redis/"]
COPY ["Services/Contact/Registration/NetCoreProject.Services.Contact.Registration/NetCoreProject.Services.Contact.Registration.csproj", "Services/Contact/Registration/NetCoreProject.Services.Contact.Registration/"]
COPY ["Services/Contact/Business/NetCoreProject.Services.Contact.Business.Mapper/NetCoreProject.Services.Contact.Business.Mapper.csproj", "Services/Contact/Business/NetCoreProject.Services.Contact.Business.Mapper/"]
COPY ["Services/Contact/Model/NetCoreProject.Services.Contact.Model.CacheModel/NetCoreProject.Services.Contact.Model.CacheModel.csproj", "Services/Contact/Model/NetCoreProject.Services.Contact.Model.CacheModel/"]
COPY ["Services/Contact/Model/NetCoreProject.Services.Contact.Model.Exchange/NetCoreProject.Services.Contact.Model.Exchange.csproj", "Services/Contact/Model/NetCoreProject.Services.Contact.Model.Exchange/"]
COPY ["Services/Contact/Business/NetCoreProject.Services.Contact.Business.Operation/NetCoreProject.Services.Contact.Business.Operation.csproj", "Services/Contact/Business/NetCoreProject.Services.Contact.Business.Operation/"]
COPY ["Services/Contact/Common/Extensions/NetCoreProject.Services.Contact.Common.Extensions.Validation/NetCoreProject.Services.Contact.Common.Extensions.Validation.csproj", "Services/Contact/Common/Extensions/NetCoreProject.Services.Contact.Common.Extensions.Validation/"]
COPY ["Services/Contact/Data/NetCoreProject.Services.Contact.Data.Interfaces/NetCoreProject.Services.Contact.Data.Interfaces.csproj", "Services/Contact/Data/NetCoreProject.Services.Contact.Data.Interfaces/"]
COPY ["Services/Contact/Data/ApplicationSetting/Services.Contact.Data.ApplicationSetting.Manager/Services.Contact.Data.ApplicationSetting.Manager.csproj", "Services/Contact/Data/ApplicationSetting/Services.Contact.Data.ApplicationSetting.Manager/"]
COPY ["Architecture/Data/Configuration/NetCoreProject.Architecture.Data.Configuration.ConfigurationManager/NetCoreProject.Architecture.Data.Configuration.ConfigurationManager.csproj", "Architecture/Data/Configuration/NetCoreProject.Architecture.Data.Configuration.ConfigurationManager/"]
COPY ["Services/Contact/Common/Constants/NetCoreProject.Services.Contact.Common.Constants.Contact/NetCoreProject.Services.Contact.Common.Constants.Contact.csproj", "Services/Contact/Common/Constants/NetCoreProject.Services.Contact.Common.Constants.Contact/"]
RUN dotnet restore "Services/Contact/Web/NetCoreProject.Services.Contact.Web/NetCoreProject.Services.Contact.Web.API.csproj"
COPY . .
WORKDIR "/src/Services/Contact/Web/NetCoreProject.Services.Contact.Web"
RUN dotnet build "NetCoreProject.Services.Contact.Web.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCoreProject.Services.Contact.Web.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCoreProject.Services.Contact.Web.API.dll"]