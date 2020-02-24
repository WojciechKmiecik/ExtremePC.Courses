#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/ExtremePC.Courses.WebApi/ExtremePC.Courses.WebApi.csproj", "src/ExtremePC.Courses.WebApi/"]
RUN dotnet restore "src/ExtremePC.Courses.WebApi/ExtremePC.Courses.WebApi.csproj"
COPY . .
WORKDIR "/src/src/ExtremePC.Courses.WebApi"
RUN dotnet build "ExtremePC.Courses.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExtremePC.Courses.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExtremePC.Courses.WebApi.dll"]