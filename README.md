# SimpleAgileBoard

Requirements to run on local environment: 

* .NET Core 3.1,
* IIS Express (using Visual Studio)
* SQL Server 
* npm for Node.js

Change connection string in "appsettings.json" which is in SimpleAgileBoard.Web project to your local SQL Server instance:

    "DefaultConnection": "Server=localhost;Database=SimpleAgileBoard;Integrated Security=True;"

Install dotnet ef through PowerShell

    dotnet tool install --global dotnet-ef


Apply migrations running command in PowerShell (SimpleAgileBoard.Persistence project folder)

    dotnet ef database update

Open solution in Visual studio and start application (it might take a while for the first time since all npm packages will be downloaded).

Example admin credentials:

* Email: "admin@admin.com"
* Password: "admin"
