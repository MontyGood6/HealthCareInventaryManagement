# ================= BUILD STAGE =================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Project files copy karo
COPY . .

# Restore & publish
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# ================= RUNTIME STAGE =================
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Build output copy karo
COPY --from=build /app/publish .

# Render ke liye port
ENV ASPNETCORE_URLS=http://0.0.0.0:10000
EXPOSE 10000

# App start command
ENTRYPOINT ["dotnet", "Healthcare.InventoryManagement.API.dll"]
