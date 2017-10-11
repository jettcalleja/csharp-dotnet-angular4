# `csharp-dotnet-angular4`

Requirements
-----
1. SQL SERVER 2017
2. .NET Core (VS Code)
3. Node.js version 6.11.* or higher

## Running the application
1. Download zip or git clone
2. Import `database/schema.sql`
  ```sh
  $ sqlcmd -S localhost -U SA -i database/schema.sql
  ```
3. install `dotnet` [dotnet core](https://www.microsoft.com/net/core)
4. Install `Angular-CLI`
  ```sh
  $ npm install -g @angular/cli
  ```
5. Install dependencies
  ```sh
  $ npm install
  ```
6. Build the Angular application
  ```sh
  $ ng build
  ```

7. .NET Core build then restore
  ```sh
  $ dotnet build
  $ dotnet restore
  ```

8. Finally, run the server
  ```sh
  $ dotnet run
  ```

Magic happens at `http://localhost:5000/` <3

## Angular-CLI

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 1.4.5.

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
