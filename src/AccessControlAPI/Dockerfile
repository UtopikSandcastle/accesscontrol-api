# Build project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App
# Copy everything
COPY . ./
# Add OpenAPI tools
RUN dotnet tool install Swashbuckle.AspNetCore.Cli --version 6.5.0
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["bash", "-c", "dotnet `echo $(basename /App/*.deps.json .deps.json)`.dll"]