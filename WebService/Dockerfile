# Step 1: Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the csproj file and restore any dependencies (via nuget)
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the code and build the application
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Step 2: Set up the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the built app from the build image
COPY --from=build /app/publish .

# Step 3: Set the entry point to run the application
ENTRYPOINT ["dotnet", "WebService.dll"]
