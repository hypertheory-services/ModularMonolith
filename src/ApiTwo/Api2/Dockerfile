#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/ApiTwo/Api2/Api2.csproj", "src/ApiTwo/Api2/"]
COPY ["src/Libs/SharedUtils/SharedUtils.csproj", "src/Libs/SharedUtils/"]
RUN dotnet restore "src/ApiTwo/Api2/Api2.csproj"
COPY . .
WORKDIR "/src/src/ApiTwo/Api2"
RUN dotnet build "Api2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api2.dll"]