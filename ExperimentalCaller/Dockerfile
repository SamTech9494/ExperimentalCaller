FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ExperimentalCaller/ExperimentalCaller.csproj", "ExperimentalCaller/"]
RUN dotnet restore "ExperimentalCaller/ExperimentalCaller.csproj"
COPY . .
WORKDIR "/src/ExperimentalCaller"
RUN dotnet build "ExperimentalCaller.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExperimentalCaller.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExperimentalCaller.dll"]
