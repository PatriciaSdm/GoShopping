#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/services/GoShopping.Order.API/GoShopping.Order.API.csproj", "src/services/GoShopping.Order.API/"]
RUN dotnet restore "src/services/GoShopping.Order.API/GoShopping.Order.API.csproj"
COPY . .
WORKDIR "/src/src/services/GoShopping.Order.API"
RUN dotnet build "GoShopping.Order.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GoShopping.Order.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GoShopping.Order.API.dll"]