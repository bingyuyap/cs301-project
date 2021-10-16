# Usage 
### Dependencies
MySQL server

### Configuration 
Add this file at root directory and below configurations 
```sh
// appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": {
      "Machine-Name": "server=<host-url>;uid=<mysql-user>;pwd=<mysql-password>;database=<db-name>;",
    }
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```