#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["UNC_SelfService_DataAccessAPI_Endpoint/UNC_SelfService_DataAccessAPI_Endpoint.csproj", "UNC_SelfService_DataAccessAPI_Endpoint/"]
RUN dotnet restore "UNC_SelfService_DataAccessAPI_Endpoint/UNC_SelfService_DataAccessAPI_Endpoint.csproj"
COPY . .
WORKDIR "/src/UNC_SelfService_DataAccessAPI_Endpoint"
RUN dotnet build "UNC_SelfService_DataAccessAPI_Endpoint.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UNC_SelfService_DataAccessAPI_Endpoint.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UNC_SelfService_DataAccessAPI_Endpoint.dll"]