FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GameLibraryAPI/GameLibraryAPI.csproj", "GameLibraryAPI/"]
RUN dotnet restore "GameLibraryAPI/GameLibraryAPI.csproj"
COPY . .
WORKDIR "/src/GameLibraryAPI"
RUN dotnet build "GameLibraryAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameLibraryAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameLibraryAPI.dll"]
