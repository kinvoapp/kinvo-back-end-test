#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Aliquota.Host/Aliquota.Host.csproj", "src/Aliquota.Host/"]
RUN dotnet restore "src/Aliquota.Host/Aliquota.Host.csproj"
COPY . .
WORKDIR "/src/src/Aliquota.Host"
RUN dotnet build "Aliquota.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aliquota.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aliquota.Host.dll"]