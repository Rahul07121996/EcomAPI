# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source
COPY EcomAPI/*.csproj .
RUN dotnet restore
COPY EcomAPI/ .
RUN dotnet build -c Release

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /source/bin/Release/net8.0/ .
EXPOSE 5080
CMD ["dotnet", "EcomAPI.dll"]