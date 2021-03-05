FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CicekSepeti.Presentation.API/CicekSepeti.Presentation.API.csproj", "CicekSepeti.Presentation.API/"]
COPY ["CicekSepeti.Data.Repository.Derived.EFSQL/CicekSepeti.Data.Repository.Derived.EFSQL.csproj", "CicekSepeti.Data.Repository.Derived.EFSQL/"]
COPY ["CicekSepeti.Data.Model.Infrastructure/CicekSepeti.Data.Model.Infrastructure.csproj", "CicekSepeti.Data.Model.Infrastructure/"]
COPY ["CicekSepeti.Core.Infrastructure/CicekSepeti.Core.Infrastructure.csproj", "CicekSepeti.Core.Infrastructure/"]
COPY ["CicekSepeti.Core.Dependency/CicekSepeti.Core.Dependency.csproj", "CicekSepeti.Core.Dependency/"]
COPY ["CicekSepeti.Data.Repository.Infrastructure/CicekSepeti.Data.Repository.Infrastructure.csproj", "CicekSepeti.Data.Repository.Infrastructure/"]
COPY ["CicekSepeti.Operation.OperationManager/CicekSepeti.Operation.OperationManager.csproj", "CicekSepeti.Operation.OperationManager/"]
COPY ["CicekSepeti.Model.DtoModel/CicekSepeti.Model.DtoModel.csproj", "CicekSepeti.Model.DtoModel/"]
COPY ["CicekSepeti.Model.ViewModel/CicekSepeti.Model.ViewModel.csproj", "CicekSepeti.Model.ViewModel/"]
COPY ["CicekSepeti.Operation.BusinessOperation/CicekSepeti.Operation.BusinessOperation.csproj", "CicekSepeti.Operation.BusinessOperation/"]
COPY ["CicekSepeti.Core.Api/CicekSepeti.Core.Api.csproj", "CicekSepeti.Core.Api/"]
COPY ["CicekSepeti.Operation.ValidationOperation/CicekSepeti.Operation.ValidationOperation.csproj", "CicekSepeti.Operation.ValidationOperation/"]
COPY ["CicekSepeti.Validation.DtoValidation/CicekSepeti.Validation.DtoValidation.csproj", "CicekSepeti.Validation.DtoValidation/"]
RUN dotnet restore "CicekSepeti.Presentation.API/CicekSepeti.Presentation.API.csproj"
COPY . .
WORKDIR "/src/CicekSepeti.Presentation.API"
RUN dotnet build "CicekSepeti.Presentation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CicekSepeti.Presentation.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CicekSepeti.Presentation.API.dll"]