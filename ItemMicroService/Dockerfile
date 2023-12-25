#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ItemMicroService/ItemMicroService.csproj", "ItemMicroService/"]
COPY ["Business/Model/Model.csproj", "Business/Model/"]
COPY ["Data/Entity/Entity.csproj", "Data/Entity/"]
COPY ["Ioc/Ioc.Test/Ioc.Test.csproj", "Ioc/Ioc.Test/"]
COPY ["Data/Context/Context.csproj", "Data/Context/"]
COPY ["Data/Context.Interface/Context.Interface.csproj", "Data/Context.Interface/"]
COPY ["Ioc/Ioc/Ioc.csproj", "Ioc/Ioc/"]
COPY ["Business/Service.Interface/Service.Interface.csproj", "Business/Service.Interface/"]
COPY ["Data/Repository.Interface/Repository.Interface.csproj", "Data/Repository.Interface/"]
COPY ["Data/Repository/Repository.csproj", "Data/Repository/"]
COPY ["Business/Service/Service.csproj", "Business/Service/"]
COPY ["ItemMicroService/ItemMicroService/Business/Mapper/Mapper.csproj", "Business/Mapper/"]
RUN dotnet restore "./ItemMicroService/./ItemMicroService.csproj"
COPY . .
WORKDIR "/src/ItemMicroService"
RUN dotnet build "./ItemMicroService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ItemMicroService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ItemMicroService.dll"]
