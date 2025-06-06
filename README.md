# BookingAPI

Demo-API for meeting reservations

## Setup & Run Instructions

1. Clone repository by runnig git clone command:
```bash
  git clone https://github.com/Bodya01/BookingAPI.git
```

2. How to run?

If you are using Docker:
1) In PowerShell open a folder which contains .sln file
2) Run:
```bash
  docker-compose up --build
```

Otherwise (build & run without Docker):
1) Ensure the connection string in appsettings.json is valid (points to your database)
2) In PowerShell (or your preferred terminal), navigate to the folder that contains the .sln file
3) Restore all dependencies:
```bash
  dotnet restore
```
4) Build the solution:
```bash
  dotnet build
```
5) Run the API:
```bash
  dotnet run --project BookingAPI/BookingAPI.csproj
```

Go to:
http://localhost:5000/swagger/index.html - if you are using Docker
https://localhost:7277/swagger/index.html - if not

To use the API you will need to register a user:
1) Send POST request to /identity/sign-up (if you already have a user - just use sign-in)
2) Copy JWT token from response
3) Paste it to Authorize modal (button is located above endpoint list)

## Short Explanation of Design Choices

1. Implemented using DDD/Clean Architecture
   1) Separated the codebase into layers (Domain, Application, Infrastructure, Presentation)
   2) Business logic (entities, value objects, domain services) lives in the Domain layer
   3) Use cases and command/query handlers are in the Application layer
2. Dropped Domain Events
   1) To keep the initial implementation simple, Event Dispatcher and domain-level events were omitted
3. Simple JWT auth
   1) User registration (/identity/sign-up) and login (/identity/sign-in) issue JWT tokens
   2) Controllers use the [Authorize] attribute to protect endpoints
   3) Token generation and validation are handled via ASP.NET Core Identity and JWT middleware.
4. Global exception handling to achieve customized responses

## Rules
1. No double-bookings in the same room (overlap check)
2. End time must be after start time
3. Booking cannot be in the past

Thanks for your attention!
