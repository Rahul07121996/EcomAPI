FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EcomAPI/EcomAPI.csproj", "EcomAPI/"]
RUN dotnet restore "EcomAPI/EcomAPI.csproj"
COPY . .
WORKDIR "/src/EcomAPI"
RUN dotnet build "EcomAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EcomAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EcomAPI.dll"]