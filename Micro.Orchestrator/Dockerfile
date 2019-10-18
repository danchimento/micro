FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Micro.Orchestrator/Micro.Orchestrator.csproj", "Micro.Orchestrator/"]
RUN dotnet restore "Micro.Orchestrator/Micro.Orchestrator.csproj"
COPY . .
WORKDIR "/src/Micro.Orchestrator"
RUN dotnet build "Micro.Orchestrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Micro.Orchestrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Micro.Orchestrator.dll"]