# Azure deployment steps

## Azure portal

#### 1. Create Web App (Azure App Service)

- Your ASP.NET Core application will live here

#### 2. Create Azure SQL Database

- After creation, check the "_Show connection string_" link under the created Azure SQL database information
- Copy the connection string information (don't forget to replace `{Username}` and `{Password}` placeholders)

## Visual Studio

#### 1. Create `appsettings.Production.json`

- Contains configuration data specific for production 
- Fill it with specific database connection string copied from the Azure portal
- Fill it with other production specific configuration keys (e.g. Facebook App Secret)
  
#### 2. Publish ASP.NET Core Application

- Easy → Right-click on the ASP.NET Core project → Publish → Select created App Service
- Even easier → Set up Continuous Deployment ( [https://docs.microsoft.com/en-us/aspnet/core/publishing/azure-continuous-deployment](https://docs.microsoft.com/en-us/aspnet/core/publishing/azure-continuous-deployment) ) **(just use GitHub directly, don't use local git repository as in tutorial)**
  - Once set, you won't have to think about deployments anymore. Just push to master and you are set
          
#### 3. Publish Database schema

Our new Azure SQL database will be empty when created. Entity Framework expects some tables in there - app will break if it tries to access the database.
- **Easy and non-recommended way (only in case you have issues with the recommended steps and dangerous thoughts)**
  - Set your development database to be the newly created Azure SQL database
  - Run the app locally from Visual Studio and configure the Azure database the same way you configured the local database

- **Recommended steps**
  
  We have two EF contexts to deal with - we use **EF6 (application entities)** and **EFCore (authentication layer entities)** in our projects.
  1. **EF Core Context (ApplicationDbContext.cs)** 
    - Microsoft decided to use migrations in the template so we don't have a choice. We need to apply initial migration to the Azure SQL database.
    - Open Terminal / Command Prompt, move to ASP.NET Core project location and run commands below:

            set ASPNETCORE_ENVIRONMENT=Production
            
            dotnet ef database update -c ApplicationDbContext

  2. **Entity Framework 6 (MyDbContext.cs)** 
    - If you didn't use EF6 migrations → EF6 will auto-create the tables, no problems here.
    - If you used EF6 migrations → Apply them to Azure SQL database
      - Use `EntityFramework\update-database` command _(EntityFramework prefix is required when working with multiple entity framework versions in a single project) _
