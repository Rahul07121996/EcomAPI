FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ecomapi/ecomapi.csproj", "ecomapi/"]
RUN dotnet restore "ecomapi/ecomapi.csproj"
COPY..
WORKDIR "/src/ecomapi"
RUN dotnet publish "ecomapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish.
ENTRYPOINT ["dotnet", "ecomapi.dll"]