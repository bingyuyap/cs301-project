FROM mcr.microsoft.com/dotnet/sdk:5.0 AS builder
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore CS301-Spend-Transactions.csproj

RUN dotnet publish CS301-Spend-Transactions.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime
WORKDIR /app
COPY --from=builder /app/out .

ENTRYPOINT ["dotnet", "CS301-Spend-Transactions.dll"]