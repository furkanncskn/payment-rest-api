#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Tringle.API/Tringle.API.csproj", "Tringle.API/"]
COPY ["Tringle.Service/Tringle.Service.csproj", "Tringle.Service/"]
COPY ["Tringle.Repository/Tringle.Repository.csproj", "Tringle.Repository/"]
COPY ["Tringle.Core/Tringle.Core.csproj", "Tringle.Core/"]
RUN dotnet restore "Tringle.API/Tringle.API.csproj"
COPY . .
WORKDIR "/src/Tringle.API"
RUN dotnet build "Tringle.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tringle.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tringle.API.dll"]