# Getting Started with ASP.NET Core

I copied the following from https://docs.asp.net/en/latest/getting-started.html so that I will have a copy because it might change in the future.


### 1. Install .NET Core
### 2. Create a new .NET Core project:
```
mkdir aspnetcoreapp
cd aspnetcoreapp
dotnet new
```

### 3. Update the project.json file to add the Kestrel HTTP server package as a dependency:
``` JSON
...
"frameworks": {
    "netcoreapp1.0": {
      "dependencies": {
        "Microsoft.NETCore.App": {
          "type": "platform",
          "version": "1.0.0"
        },
        "Microsoft.AspNetCore.Server.Kestrel": "1.0.0"
      },
      "imports": "dnxcore50"
    }
...
```

### 4. Restore the packages:
`dotnet restore`

### 5. Add a Startup.cs file that defines the request handling logic:

``` C#
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace aspnetcoreapp
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(context =>
            {
                return context.Response.WriteAsync("Hello from ASP.NET Core!");
            });
        }
    }
}
```

### 6. Update the code in Program.cs to setup and start the Web host:

``` C#
using System;
using Microsoft.AspNetCore.Hosting;

namespace aspnetcoreapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
```

### 7. Run the app (the dotnet run command will build the app when it’s out of date):

`dotnet run`

### 8. Browse to http://localhost:5000