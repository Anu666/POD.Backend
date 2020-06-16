FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["POD.Services.API/POD.Services.API.csproj", "POD.Services.API/"]
COPY ["POD.Models/POD.Models.csproj", "POD.Models/"]
COPY ["POD.StaticData/POD.StaticData.csproj", "POD.StaticData/"]
RUN dotnet restore "POD.Services.API/POD.Services.API.csproj"
COPY . .
WORKDIR "/src/POD.Services.API"
RUN dotnet build "POD.Services.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POD.Services.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
ENTRYPOINT ["dotnet", "POD.Services.API.dll"]