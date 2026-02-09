FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Volunteer.API/Volunteer.API.csproj", "src/Volunteer.API/"]
COPY ["src/Volunteer.Application/Volunteer.Application.csproj", "src/Volunteer.Application/"]
COPY ["src/Volunteer.Domain/Volunteer.Domain.csproj", "src/Volunteer.Domain/"]
COPY ["src/Volunteer.Infrastructure/Volunteer.Infrastructure.csproj", "src/Volunteer.Infrastructure/"]
RUN dotnet restore "src/Volunteer.API/Volunteer.API.csproj"
COPY . .
WORKDIR "/src/src/Volunteer.API"
RUN dotnet build "./Volunteer.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Volunteer.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Volunteer.API.dll"]
