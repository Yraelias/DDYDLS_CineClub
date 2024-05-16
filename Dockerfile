#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8083

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DDYDLS_CineClub/DDYDLS_CineClubApi.csproj", "DDYDLS_CineClub/"]
COPY ["DDYDLS_CineClubLocalModel/DDYDLS_CineClubLocalModel.csproj", "DDYDLS_CineClubLocalModel/"]
COPY ["DDYDLS_CineClubRepository/DDYDLS_CineClubDAL.csproj", "DDYDLS_CineClubRepository/"]
RUN dotnet restore "./DDYDLS_CineClub/DDYDLS_CineClubApi.csproj"
COPY . .
WORKDIR "/src/DDYDLS_CineClub"
RUN dotnet build "./DDYDLS_CineClubApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DDYDLS_CineClubApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DDYDLS_CineClubApi.dll"]
