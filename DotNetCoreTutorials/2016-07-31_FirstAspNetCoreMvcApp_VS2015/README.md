# Building your first ASP.NET Core MVC app with Visual Studio

This tutorial is from https://docs.asp.net/en/latest/tutorials/first-mvc-app/index.html

## Install Visual Studio and .NET Core

Install Visual Studio Community 2015

Install [.NET Core + Visual Studio tooling](http://go.microsoft.com/fwlink/?LinkID=798306)

## Create a web app

Complete the New Project dialog:

* In the left pane, tap Web
* In the center pane, tap **ASP.NET Core Web Application (.NET Core)**
* Name the project “MvcMovie” (It’s important to name the project “MvcMovie” so when you copy code, the namespace will match. )
* Tap OK

Complete the New ASP.NET Core Web Application - MvcMovie dialog:

* Tap Web Application
* Clear Host in the cloud
* Tap OK.

Tap F5 to run the app in debug mode or Ctl-F5 in non-debug mode.


## Adding a controller

In Solution Explorer, right-click Controllers > Add > New Item... > MVC Controller Class

In the Add New Item dialog, enter HelloWorldController.
``` C#
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
```

Every public method in a controller is callable as an HTTP endpoint. 

The default URL routing logic used by MVC uses a format like this to determine what code to invoke:
```
/[Controller]/[ActionName]/[Parameters]
```

You set the format for routing in the Startup.cs file.
``` C#
    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
    });
}
```

# NOTE: July 31, 2016 - Not Yet Finished because I did the tutorial on Web API instead because it is shorter (and I will be using it in my next practice project) and it loads much faster...
