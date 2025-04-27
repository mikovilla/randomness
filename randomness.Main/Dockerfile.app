# --- .NET Benchmark Job ---

# Base image for .NET SDK (includes runtime & CLI)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["randomness.Main/randomness.Main.csproj", "randomness.Main/"]
COPY ["randomness.Application/randomness.Application.csproj", "randomness.Application/"]

# Restore dependencies
RUN dotnet restore "./randomness.Main/randomness.Main.csproj"

# Copy source code and build application
COPY . .
WORKDIR "/src/randomness.Main"
RUN dotnet build "./randomness.Main.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "./randomness.Main.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime image with full .NET support
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Set entrypoint to execute .NET job
ENTRYPOINT ["/usr/bin/dotnet", "/app/randomness.Main.dll"]
