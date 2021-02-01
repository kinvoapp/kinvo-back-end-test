#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Aliquota.WEB/Aliquota.WEB.csproj", "Aliquota.WEB/"]
RUN dotnet restore "Aliquota.WEB/Aliquota.WEB.csproj"
COPY . .
WORKDIR "/src/Aliquota.WEB"
RUN dotnet build "Aliquota.WEB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aliquota.WEB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aliquota.WEB.dll"]