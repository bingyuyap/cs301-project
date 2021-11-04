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

```json
// launchSettings.json
{
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:13361",
      "sslPort": 44368
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "CS301_Spend_Transactions": {
      "commandName": "Project",
      // false since we do not want this to pop up everything we run
      "launchBrowser": false,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "QueueUrl": <queue url>,
        "SQSRegion": <queue region>,
        "AccessKey": <access key>,
        "SecretKey": <secret key>
      }
    }
  }
}

```

Replace the variables `<Machine-Name>`, `<host-url>`, `<mysql-user>`, `<mysql-password>` and `<db-name>` 
with the relevant values for your local machine 