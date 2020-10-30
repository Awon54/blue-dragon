# Blue Dragon

You must have the .NET SDK installed. .NET Core 3.1 is recommended.

## Technologies
- Framework: dotnet core Entity Framework
- Database: sqlite
- API Visualization: Swagger UI
- Basic Authentication
	- Static credential
		username: test
		password: test
  
## Run
- Clone the project
- Install dotnet cli or Visual Studio

### [Visual Studio](https://visualstudio.microsoft.com/downloads/)

- Import blue-dragon.sln
- Use IIS Express to start the app
### To check existing APIs
- automatically opens swagger UI in the browser.



### [Dotnet Cli](https://docs.microsoft.com/en-us/dotnet/core/tools/)

- from blue-dragon/blue-dragon run `dotnet run`
#### Test:
- open [localhost:5001/swagger](localhost:5001/swagger) on your browser.

## Setting up DB (Optional)
*Note: Already setup, Use only if necessary*

- `dotnet ef migrations add InitialCreate`
- `dotnet ef database update`


