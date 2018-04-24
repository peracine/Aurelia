# Aurelia & .Net Core

## Setting up your machine with VS 2017
 * .NET CLI from https://www.microsoft.com/net/core
 * Node.js from https://nodejs.org

## Creating the project
 -> Aurelia doesn't come as a standard template
```
 dotnet new --install "Microsoft.AspNetCore.SpaTemplates::*"
 dotnet new aurelia -o "Path/To/The/Project" --force
```

## Features
* Nlog (https://github.com/NLog/NLog.Web/wiki/Getting-started-with-ASP.NET-Core-2) 
	Bug concerning internalLogFile https://github.com/NLog/NLog.Web/issues/201
* EF Core
