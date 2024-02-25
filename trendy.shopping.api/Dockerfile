#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["trendy.shopping/trendy.shopping.api/trendy.shopping.api.csproj", "trendy.shopping/trendy.shopping.api/"]
RUN dotnet restore "./trendy.shopping/trendy.shopping.api/trendy.shopping.api.csproj"
COPY . .
WORKDIR "/src/trendy.shopping/trendy.shopping.api"
RUN dotnet build "./trendy.shopping.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "./trendy.shopping.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "trendy.shopping.api.dll"]