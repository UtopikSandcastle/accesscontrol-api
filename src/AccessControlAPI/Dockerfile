# Build project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App
# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Generate OpenApi configuration file
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-openapi
WORKDIR /App
COPY --from=build-env /App/out .
RUN dotnet new tool-manifest && \
    dotnet tool install Swashbuckle.AspNetCore.Cli && \
    dotnet swagger tofile --yaml --output openapi.yml `echo $(basename /App/*.deps.json .deps.json)`.dll v1

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
COPY --from=build-openapi /App/openapi.yml .
ENTRYPOINT ["bash", "-c", "dotnet `echo $(basename /App/*.deps.json .deps.json)`.dll"]