project created with 
```
dotnet new web api
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package MailKit

dotnet tool install dotnet-ef --global
dotnet tool install dotnet-aspnet-codegenerator

dotnet ef dbcontext scaffold "Server=RLSFT20002\SQLEXPRESS;Database=MissingItemReports;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
./GenerateAPIControllers.ps1
```
