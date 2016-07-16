# Your First ASP.NET Core Application (on a Mac [Windows in my case]) Using Visual Studio Code

Summary from https://docs.asp.net/en/latest/tutorials/your-first-mac-aspnet.html


## 0. Setup

### Setup your development machine 
 - download and install .NET Core and Visual Studio Code with the C# extension.

### Scaffolding Applications Using Yeoman

(from https://docs.asp.net/en/latest/client-side/yeoman.html)

#### a. Install yo using npm

upgrade npm if needed
```
npm install -g npm
```

```
npm install -g yo
```


#### b. From the command line, install the ASP.NET generator:
```
npm install -g generator-aspnet
```

> **The `–g` flag installs the generator globally, so that it can be used from any path.**


## 1. Create an ASP.NET app

### Create a directory for your projects
```
mkdir src
cd src
```

### Run the ASP.NET generator for yo
```
yo aspnet
```

The generator displays a menu. Arrow down to the **Empty Web Application** project and tap Enter:

### Restore, build and run

#### 1. Follow the suggested commands by changing directories to the `EmptyWeb1` directory. 
#### 2. Then run `dotnet restore`.
#### 3. Build and run the app using `dotnet build` and `dotnet run`:

## 2. Developing ASP.NET Core Applications (on a Mac [Windows in my case]) With Visual Studio Code

### Open your project in Visual Studio Code 

### `dotnet restore` or `command shift p` then type `dot`

From a Terminal / bash prompt, run `dotnet restore` to restore the project’s dependencies. Alternately, you can enter `command shift p` in Visual Studio Code and then type `dot` as shown:


## 3. Running Locally Using Kestrel

``` JSON
 "dependencies": {
    "Microsoft.NETCore.App": {
      "type": "platform",
      "version": "1.0.0"
    },
    "Microsoft.AspNetCore.Server.Kestrel": "1.0.0"
  },
```

### Run `dotnet run` command to launch the app
### Navigate to `localhost:5000`
### To stop the web server enter `Ctrl+C`


## 4. Publishing to Azure - wala ko na ni gihimo kay wala koy Azure