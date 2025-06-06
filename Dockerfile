FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY BookingAPI.sln ./
COPY BookingAPI.Domain/BookingAPI.Domain.csproj         BookingAPI.Domain/
COPY BookingAPI.Application/BookingAPI.Application.csproj  BookingAPI.Application/
COPY BookingAPI.Infrastructure/BookingAPI.Infrastructure.csproj BookingAPI.Infrastructure/
COPY BookingAPI.Presentation/BookingAPI.Presentation.csproj  BookingAPI.Presentation/

RUN dotnet restore

COPY . .
WORKDIR /src/BookingAPI.Presentation
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish ./

RUN apt-get update \
 && apt-get install -y --no-install-recommends curl \
 && curl -fsSL https://raw.githubusercontent.com/vishnubob/wait-for-it/master/wait-for-it.sh -o /app/wait-for-it.sh \
 && chmod +x /app/wait-for-it.sh \
 && apt-get remove -y curl \
 && apt-get autoremove -y \
 && rm -rf /var/lib/apt/lists/*

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["/app/wait-for-it.sh", "db:1433", "--", "dotnet", "BookingAPI.Presentation.dll"]
