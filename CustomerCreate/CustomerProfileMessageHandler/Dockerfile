FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["CustomerProfileMessageHandler/CustomerProfileMessageHandler.csproj", "CustomerProfileMessageHandler/"]
RUN dotnet restore "CustomerProfileMessageHandler/CustomerProfileMessageHandler.csproj"
COPY . .
WORKDIR "/src/CustomerProfileMessageHandler"
RUN dotnet build "CustomerProfileMessageHandler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerProfileMessageHandler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerProfileMessageHandler.dll"]
