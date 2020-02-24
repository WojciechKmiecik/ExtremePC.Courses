#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/ExtremePC.Courses.Worker/ExtremePC.Courses.Worker.csproj", "src/ExtremePC.Courses.Worker/"]
RUN dotnet restore "src/ExtremePC.Courses.Worker/ExtremePC.Courses.Worker.csproj"
COPY . .
WORKDIR "/src/src/ExtremePC.Courses.Worker"
RUN dotnet build "ExtremePC.Courses.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExtremePC.Courses.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExtremePC.Courses.Worker.dll"]