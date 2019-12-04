FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Kibol-Alert.csproj", ""]
RUN dotnet restore 
COPY . .
WORKDIR "/src/."
RUN dotnet build "Kibol-Alert.csproj" -c Release -o /app/build


WORKDIR "/src/Kibol-Alert.Tests/."
COPY Kibol-Alert.Tests .
RUN dotnet test

FROM build AS publish
RUN dotnet publish "Kibol-Alert.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kibol-Alert.dll"]
