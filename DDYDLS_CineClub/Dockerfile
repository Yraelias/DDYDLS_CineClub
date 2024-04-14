#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["DDYDLS_CineClub/DDYDLS_CineClub.csproj", "DDYDLS_CineClub/"]

RUN dotnet restore "DDYDLS_CineClub/DDYDLS_CineClub.csproj"
COPY . ./
WORKDIR /src
RUN dotnet build "DDYDLS_CineClub.csproj" -c $BUILD_CONFIGURATION -o /app/build

RUN mkdir -p app/build/ddydls_cineclubdevops

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DDYDLS_CineClub.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DDYDLS_CineClub.dll"]