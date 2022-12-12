#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MuffinCTF/MuffinCTF.csproj", "MuffinCTF/"]
COPY ["MuffinCTF.Application/MuffinCTF.Application.csproj", "MuffinCTF.Application/"]
COPY ["MuffinCTF.Database/MuffinCTF.Database.csproj", "MuffinCTF.Database/"]
COPY ["MuffinCTF.Domain/MuffinCTF.Domain.csproj", "MuffinCTF.Domain/"]
RUN dotnet restore "MuffinCTF/MuffinCTF.csproj"
COPY . .
WORKDIR "/src/MuffinCTF"
RUN dotnet build "MuffinCTF.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MuffinCTF.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MuffinCTF.dll"]