# Build project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App
# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Generate OpenApi configuration file
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-openapi
WORKDIR /App
COPY --from=build-env /App/out .
RUN dotnet new tool-manifest && \
    dotnet tool install DotSwashbuckle.AspNetCore.Cli --version 3.0.1 && \
    dotnet swagger tofile --yaml --output openapi.json `echo $(basename /App/*.deps.json .deps.json)`.dll v1

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
COPY --from=build-openapi /App/openapi.json .
ENTRYPOINT ["bash", "-c", "dotnet `echo $(basename /App/*.deps.json .deps.json)`.dll"]