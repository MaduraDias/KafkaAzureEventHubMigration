FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Customer/CustomerUi.csproj", "Customer/"]
RUN dotnet restore "Customer/CustomerUi.csproj"
COPY . .
WORKDIR "/src/Customer"
RUN dotnet build "CustomerUi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerUi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerUi.dll"]
