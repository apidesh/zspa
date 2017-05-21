# ZSPA
 .NET Core project + AngularJs 2 + Entity Framework Core


Installation Guide
===================
1.  Install .NET Core (Install for Windows - Command Line, Skip if you are already installed with VS.NET 2017)
    http://microsoft.com/net/core#windowscmd
2.  Install NodeJs
    https://nodejs.org
3. Install npm 
      - npm install -g npm
4. Install webpack
      - npm install webpack -g
5. Install EF Core 
    - Install-Package Microsoft.EntityFrameworkCore.SqlServer
    - Install-Package Microsoft.EntityFrameworkCore.Tools

6. Clone the project at https://github.com/apidesh/zspa.git

7. Create Database instance and table from ./DbScript/create-db.sql

8. Install webpack
   npm install webpack -g
9. Webpack Build
    - webpack --config webpack.config.vendor.js
    - webpack --config webpack.config.js
   The output file will store inton ./ClientApp/dist and ./wwwroot/dist
   
10. Start working with the project 
    - 10.1 Visual Studio 2015/2017 from ZSPA.sln 
    - 10.2 Visual Studio Code + Console command "dotnet run"
 

   
