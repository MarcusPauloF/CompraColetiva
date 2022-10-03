#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/View/acme.sistemas.compracoletiva.api/acme.sistemas.compracoletiva.api.csproj", "src/View/acme.sistemas.compracoletiva.api/"]
RUN dotnet restore "src/View/acme.sistemas.compracoletiva.api/acme.sistemas.compracoletiva.api.csproj"
COPY . .
WORKDIR "/src/src/View/acme.sistemas.compracoletiva.api"
RUN dotnet build "acme.sistemas.compracoletiva.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "acme.sistemas.compracoletiva.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "acme.sistemas.compracoletiva.api.dll"]