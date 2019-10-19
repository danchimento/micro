FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Micro.Auth/Micro.Auth.csproj", "Micro.Auth/"]
RUN dotnet restore "Micro.Auth/Micro.Auth.csproj"
COPY . .
WORKDIR "/src/Micro.Auth"
RUN dotnet build "Micro.Auth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Micro.Auth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Micro.Auth.dll"]