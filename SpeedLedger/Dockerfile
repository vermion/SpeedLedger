FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 60913
EXPOSE 44363

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["SpeedLedger/SpeedLedger.csproj", "SpeedLedger/"]
RUN dotnet restore "SpeedLedger/SpeedLedger.csproj"
COPY . .
WORKDIR "/src/SpeedLedger"
RUN dotnet build "SpeedLedger.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SpeedLedger.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SpeedLedger.dll"]