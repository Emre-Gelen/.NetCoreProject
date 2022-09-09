#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Classroom/Web/NetCoreProject.Services.Classroom.Web.API/NetCoreProject.Services.Classroom.Web.API.csproj", "Services/Classroom/Web/NetCoreProject.Services.Classroom.Web.API/"]
COPY ["Architecture/Registration/NetCoreProject.Architecture.Registration.Redis/NetCoreProject.Architecture.Registration.Redis.csproj", "Architecture/Registration/NetCoreProject.Architecture.Registration.Redis/"]
COPY ["Architecture/Data/Cache/NetCoreProject.Architecture.Data.Cache.Interfaces/NetCoreProject.Architecture.Data.Cache.Interfaces.csproj", "Architecture/Data/Cache/NetCoreProject.Architecture.Data.Cache.Interfaces/"]
COPY ["Architecture/Data/Cache/Redis/NetCoreProject.Architecture.Data.Cache.Redis/NetCoreProject.Architecture.Data.Cache.Redis.csproj", "Architecture/Data/Cache/Redis/NetCoreProject.Architecture.Data.Cache.Redis/"]
COPY ["Services/Classroom/Model/NetCoreProject.Services.Classroom.Model.Exchange/NetCoreProject.Services.Classroom.Model.Exchange.csproj", "Services/Classroom/Model/NetCoreProject.Services.Classroom.Model.Exchange/"]
COPY ["Services/Classroom/Registration/NetCoreProject.Services.Classroom.Registration/NetCoreProject.Services.Classroom.Registration.csproj", "Services/Classroom/Registration/NetCoreProject.Services.Classroom.Registration/"]
COPY ["Services/Classroom/Business/NetCoreProject.Services.Classroom.Business.Operation/NetCoreProject.Services.Classroom.Business.Operation.csproj", "Services/Classroom/Business/NetCoreProject.Services.Classroom.Business.Operation/"]
COPY ["Services/Classroom/Data/NetCoreProject.Services.Classroom.Data.Interfaces/NetCoreProject.Services.Classroom.Data.Interfaces.csproj", "Services/Classroom/Data/NetCoreProject.Services.Classroom.Data.Interfaces/"]
COPY ["Services/Classroom/Data/Services/NetCoreProject.Services.Classroom.Data.Services.Model/NetCoreProject.Services.Classroom.Data.Services.Model.csproj", "Services/Classroom/Data/Services/NetCoreProject.Services.Classroom.Data.Services.Model/"]
COPY ["Services/Classroom/Model/NetCoreProject.Services.Classroom.Model.CacheModel/NetCoreProject.Services.Classroom.Model.CacheModel.csproj", "Services/Classroom/Model/NetCoreProject.Services.Classroom.Model.CacheModel/"]
COPY ["Services/Classroom/Data/ApplicationSetting/ClassLibrary1/NetCoreProject.Services.Classroom.Data.ApplicationSetting.Manager.csproj", "Services/Classroom/Data/ApplicationSetting/ClassLibrary1/"]
COPY ["Architecture/Data/Configuration/NetCoreProject.Architecture.Data.Configuration.ConfigurationManager/NetCoreProject.Architecture.Data.Configuration.ConfigurationManager.csproj", "Architecture/Data/Configuration/NetCoreProject.Architecture.Data.Configuration.ConfigurationManager/"]
COPY ["Services/Classroom/Common/Constants/NetCoreProject.Services.Classroom.Common.Constants.Lesson/NetCoreProject.Services.Classroom.Common.Constants.Lesson.csproj", "Services/Classroom/Common/Constants/NetCoreProject.Services.Classroom.Common.Constants.Lesson/"]
RUN dotnet restore "Services/Classroom/Web/NetCoreProject.Services.Classroom.Web.API/NetCoreProject.Services.Classroom.Web.API.csproj"
COPY . .
WORKDIR "/src/Services/Classroom/Web/NetCoreProject.Services.Classroom.Web.API"
RUN dotnet build "NetCoreProject.Services.Classroom.Web.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCoreProject.Services.Classroom.Web.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCoreProject.Services.Classroom.Web.API.dll"]