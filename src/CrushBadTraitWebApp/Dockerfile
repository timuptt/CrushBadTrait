FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CrushBadTrait.WebApp/CrushBadTrait.WebApp.csproj", "CrushBadTrait.WebApp/"]
COPY ["CrushBadTrait.Application/CrushBadTrait.Application.csproj", "CrushBadTrait.Application/"]
COPY ["CrushBadTrait.Infrastructure/CrushBadTrait.Infrastructure.csproj", "CrushBadTrait.Infrastructure/"]
RUN dotnet restore "CrushBadTrait.WebApp/CrushBadTrait.WebApp.csproj"
COPY . .
WORKDIR "/src/CrushBadTrait.WebApp"
RUN dotnet build "CrushBadTrait.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CrushBadTrait.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CrushBadTrait.WebApp.dll"]
