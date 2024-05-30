# Set the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Set the build image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the solution file and the project files
COPY ["GameLibraryAPI.sln", "."]
COPY ["Business/Business.csproj", "Business/"]
RUN dotnet restore "Business/Business.csproj"

# Copy the remaining project files
COPY . .
WORKDIR "/src/Business"
RUN dotnet build "Business.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Business.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Business.dll"]
