# Usage 
### Dependencies
Local installation of MySQL server  

### Configuration 
Add this file at root directory and below configurations 
```sh
// appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": {
      "<Machine-Name>": "server=<host-url>;uid=<mysql-user>;pwd=<mysql-password>;database=<db-name>;",
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

Replace the variables `<Machine-Name>`, `<host-url>`, `<mysql-user>`, `<mysql-password>` and `<db-name>` 
with the relevant values for your local machine 