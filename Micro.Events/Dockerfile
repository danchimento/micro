FROM mcr.microsoft.com/dotnet/core/runtime:3.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Micro.Events/Micro.Events.csproj", "Micro.Events/"]
RUN dotnet restore "Micro.Events/Micro.Events.csproj"
COPY . .
WORKDIR "/src/Micro.Events"
RUN dotnet build "Micro.Events.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Micro.Events.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Micro.Events.dll"]