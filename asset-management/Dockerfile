FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["asset-management.csproj", "."]
RUN dotnet restore "./asset-management.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "asset-management.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "asset-management.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "asset-management.dll"]