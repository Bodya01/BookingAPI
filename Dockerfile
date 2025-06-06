FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY BookingAPI.sln ./

COPY BookingAPI.Domain/BookingAPI.Domain.csproj         BookingAPI.Domain/
COPY BookingAPI.Application/BookingAPI.Application.csproj BookingAPI.Application/
COPY BookingAPI.Infrastructure/BookingAPI.Infrastructure.csproj BookingAPI.Infrastructure/
COPY BookingAPI.Presentation/BookingAPI.Presentation.csproj  BookingAPI.Presentation/

RUN dotnet restore

COPY . .

WORKDIR /src/BookingAPI.Presentation
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish ./

COPY wait-for-it.sh /app/wait-for-it.sh
RUN chmod +x /app/wait-for-it.sh

# 3) Listen on port 80
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["/app/wait-for-it.sh", "db:1433", "--", "dotnet", "BookingAPI.Presentation.dll"]
