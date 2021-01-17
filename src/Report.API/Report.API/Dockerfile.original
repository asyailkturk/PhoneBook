#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Report.API/Report.API/Report.API.csproj", "src/Report.API/Report.API/"]
RUN dotnet restore "src/Report.API/Report.API/Report.API.csproj"
COPY . .
WORKDIR "/src/src/Report.API/Report.API"
RUN dotnet build "Report.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Report.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Report.API.dll"]
