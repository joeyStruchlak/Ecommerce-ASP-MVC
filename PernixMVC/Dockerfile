# Use the .NET 8 SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /src

# Copy the PernixMVC.csproj and restore dependencies
COPY ["PernixMVC/PernixMVC.csproj", "PernixMVC/"]
COPY ["PernixMVC.DataAccess/PernixMVC.DataAccess.csproj", "PernixMVC.DataAccess/"]
COPY ["PernixMVC.Models/PernixMVC.Models.csproj", "PernixMVC.Models/"]
COPY ["PernixMVC.Utility/PernixMVC.Utility.csproj", "PernixMVC.Utility/"]

# Restore dependencies (This will also restore for referenced projects)
RUN dotnet restore "PernixMVC/PernixMVC.csproj"

# Copy all the source code
COPY . .

# Build the application in release mode
WORKDIR "/src/PernixMVC"
RUN dotnet build "PernixMVC.csproj" -c Release -o /app/build

# Publish the application to the /app/publish directory
RUN dotnet publish "PernixMVC.csproj" -c Release -o /app/publish

# Final image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Set the working directory for the final image
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Expose the port your app will run on (default for ASP.NET Core is 80)
EXPOSE 80

# Set the entry point to run the app
ENTRYPOINT ["dotnet", "PernixMVC.dll"]
