# Building Your First Web API with ASP.NET Core MVC and Visual Studio

### This is a summary of the tutorial from https://docs.asp.net/en/latest/tutorials/first-web-api.html

In this tutorial, you'll build a simple web API for managing a list of "to-do" items. You won't build any UI in this tutorial.

## Overview

Here is the API that you'll create:

<div class="wy-table-responsive"><table border="1" class="docutils">
<colgroup>
<col width="27%">
<col width="31%">
<col width="16%">
<col width="26%">
</colgroup>
<thead valign="bottom">
<tr class="row-odd"><th class="head">API</th>
<th class="head">Description</th>
<th class="head">Request body</th>
<th class="head">Response body</th>
</tr>
</thead>
<tbody valign="top">
<tr class="row-even"><td>GET /api/todo</td>
<td>Get all to-do items</td>
<td>None</td>
<td>Array of to-do items</td>
</tr>
<tr class="row-odd"><td>GET /api/todo/{id}</td>
<td>Get an item by ID</td>
<td>None</td>
<td>To-do item</td>
</tr>
<tr class="row-even"><td>POST /api/todo</td>
<td>Add a new item</td>
<td>To-do item</td>
<td>To-do item</td>
</tr>
<tr class="row-odd"><td>PUT /api/todo/{id}</td>
<td>Update an existing item</td>
<td>To-do item</td>
<td>None</td>
</tr>
<tr class="row-even"><td>DELETE /api/todo/{id}</td>
<td>Delete an item.</td>
<td>None</td>
<td>None</td>
</tr>
</tbody>
</table></div>

## Install Fiddler

We’re not building a client, we’ll use Fiddler to test the API. Fiddler is a web debugging tool that lets you compose HTTP requests and view the raw HTTP responses.

## Create the project

Start Visual Studio. From the File menu, select New > Project.

Select the ASP.NET Core Web Application project template. Name the project `TodoApi` and tap OK.

In the New ASP.NET Core Web Application (.NET Core) - TodoApi dialog, select the Web API template. Tap OK.

## Add a model class

Add a folder named “Models”. 

Next, add a TodoItem class. 
``` C#
namespace TodoApi.Models
{
    public class TodoItem
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
```

## Add a repository class

A repository is an object that encapsulates the data layer, and contains logic for retrieving data and mapping it to an entity model. 

Create the repository code in the Models folder.

### Start by defining a repository interface named ITodoRepository. 
``` C#
using System.Collections.Generic;

namespace TodoApi.Models
{
    public interface ITodoRepository
    {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(string key);
        TodoItem Remove(string key);
        void Update(TodoItem item);
    }
}
```

### Next, add a TodoRepository class that implements ITodoRepository:
``` C#
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace TodoApi.Models
{
    public class TodoRepository : ITodoRepository
    {
        private static ConcurrentDictionary<string, TodoItem> _todos = 
              new ConcurrentDictionary<string, TodoItem>();

        public TodoRepository()
        {
            Add(new TodoItem { Name = "Item1" });
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todos.Values;
        }

        public void Add(TodoItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Key] = item;
        }

        public TodoItem Find(string key)
        {
            TodoItem item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public TodoItem Remove(string key)
        {
            TodoItem item;
            _todos.TryGetValue(key, out item);
            _todos.TryRemove(key, out item);
            return item;
        }

        public void Update(TodoItem item)
        {
            _todos[item.Key] = item;
        }
    }
}
```

## Register the repository

In order to inject the repository into the controller, we need to register it with the DI container. Open the Startup.cs file. Add the following using directive:
```
using TodoApi.Models;
```

In the ConfigureServices method, add the code:
```
    // Add our repository type
    services.AddSingleton<ITodoRepository, TodoRepository>();
```

## Add a controller

``` C#
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        public TodoController(ITodoRepository todoItems)
        {
            TodoItems = todoItems;
        }
        public ITodoRepository TodoItems { get; set; }
    }
}
```

## Getting to-do items

To get to-do items, add the following methods to the TodoController class.
``` C#
public IEnumerable<TodoItem> GetAll()
{
    return TodoItems.GetAll();
}

[HttpGet("{id}", Name = "GetTodo")]
public IActionResult GetById(string id)
{
    var item = TodoItems.Find(id);
    if (item == null)
    {
        return NotFound();
    }
    return new ObjectResult(item);
}
```

These methods implement the two GET methods:

* `GET /api/todo`
* `GET /api/todo/{id}`

Here is an example HTTP response for the GetAll method:

``` HTTP
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Server: Microsoft-IIS/10.0
Date: Thu, 18 Jun 2015 20:51:10 GMT
Content-Length: 82

[{"Key":"4f67d7c5-a2a9-4aae-b030-16003dd829ae","Name":"Item1","IsComplete":false}]
```

### Routing and URL paths

### Return values

The GetAll method returns a CLR object. MVC automatically serializes the object to JSON and writes the JSON into the body of the response message. The response code for this method is 200, assuming there are no unhandled exceptions. (Unhandled exceptions are translated into 5xx errors.)

In contrast, the GetById method returns the more general IActionResult type, which represents a generic result type. That’s because GetById has two different return types:

* If no item matches the requested ID, the method returns a 404 error. This is done by returning NotFound.
* Otherwise, the method returns 200 with a JSON response body. This is done by returning an ObjectResult.

## Run

In Visual Studio, press ^F5 to launch the app. Visual Studio launches a browser and navigates to http://localhost:port/api/todo, where port is a randomly chosen port number. If you’re using Chrome, Edge or Firefox, the todo data will be displayed. If you’re using IE, IE will prompt to you open or save the todo.json file.

## Use Fiddler to call the API
(or you can use Postman on Chrome)

[The following HTTP request and response are copied from fiddler]
```
GET http://localhost:24822/api/todo HTTP/1.1
User-Agent: Fiddler
Host: localhost:24822
```

```
HTTP/1.1 200 OK
Transfer-Encoding: chunked
Content-Type: application/json; charset=utf-8
Server: Kestrel
X-SourceFiles: =?UTF-8?B?RDpcR2l0aHViXGpib3lmbGFnYTJcUHJvZ3JhbW1pbmdFeGVyY2lzZXMtQ1NoYXJwXERvdE5ldENvcmVUdXRvcmlhbHNcMjAxNi0wNy0zMV9GaXJzdFdlYkFQSV9Bc3BOZXRDb3JlTXZjX1ZTMjAxNVxUb2RvQXBpXHNyY1xUb2RvQXBpXGFwaVx0b2Rv?=
X-Powered-By: ASP.NET
Date: Sun, 31 Jul 2016 11:20:09 GMT

52
[{"Key":"0cbb0134-9233-4fde-bee3-e011681ce6a7","Name":"Item1","IsComplete":false}]
0
```

## Implement the other CRUD operations

### Create
``` C#
[HttpPost]
public IActionResult Create([FromBody] TodoItem item)
{
    if (item == null)
    {
        return BadRequest();
    }
    TodoItems.Add(item);
    return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
}
```

The CreatedAtRoute method returns a 201 response, which is the standard response for an HTTP POST method that creates a new resource on the server. CreateAtRoute also adds a Location header to the response. The Location header specifies the URI of the newly created to-do item. See 10.2.2 201 Created.

Request:
``` HTTP
POST http://localhost:29359/api/todo HTTP/1.1
User-Agent: Fiddler
Host: localhost:29359
Content-Type: application/json
Content-Length: 33

{"Name":"Alphabetize paperclips"}
```

Response:
``` HTTP
HTTP/1.1 201 Created
Content-Type: application/json; charset=utf-8
Location: http://localhost:29359/api/Todo/8fa2154d-f862-41f8-a5e5-a9a3faba0233
Server: Microsoft-IIS/10.0
Date: Thu, 18 Jun 2015 20:51:55 GMT
Content-Length: 97

{"Key":"8fa2154d-f862-41f8-a5e5-a9a3faba0233","Name":"Alphabetize paperclips","IsComplete":false}
```

### Update
``` C#
[HttpPut("{id}")]
public IActionResult Update(string id, [FromBody] TodoItem item)
{
    if (item == null || item.Key != id)
    {
        return BadRequest();
    }

    var todo = TodoItems.Find(id);
    if (todo == null)
    {
        return NotFound();
    }

    TodoItems.Update(item);
    return new NoContentResult();
}
```

Update is similar to Create, but uses HTTP PUT. The response is 204 (No Content). According to the HTTP spec, a PUT request requires the client to send the entire updated entity, not just the deltas. To support partial updates, use HTTP PATCH.

```
PUT http://localhost:24822/api/todo/0cbb0134-9233-4fde-bee3-e011681ce6a7 HTTP/1.1
User-Agent: Fiddler
Host: localhost:24822
Content-Type: application/json
Content-Length: 79

{"Key":"0cbb0134-9233-4fde-bee3-e011681ce6a7","Name":"Item1","IsComplete":true}
```

Response:
```
HTTP/1.1 204 No Content
Server: Kestrel
X-SourceFiles: =?UTF-8?B?RDpcR2l0aHViXGpib3lmbGFnYTJcUHJvZ3JhbW1pbmdFeGVyY2lzZXMtQ1NoYXJwXERvdE5ldENvcmVUdXRvcmlhbHNcMjAxNi0wNy0zMV9GaXJzdFdlYkFQSV9Bc3BOZXRDb3JlTXZjX1ZTMjAxNVxUb2RvQXBpXHNyY1xUb2RvQXBpXGFwaVx0b2RvXDBjYmIwMTM0LTkyMzMtNGZkZS1iZWUzLWUwMTE2ODFjZTZhNw==?=
X-Powered-By: ASP.NET
Date: Sun, 31 Jul 2016 11:32:14 GMT
```

### Delete
``` C#
[HttpDelete("{id}")]
public void Delete(string id)
{
    TodoItems.Remove(id);
}
```

The void return type returns a 204 (No Content) response. That means the client receives a 204 even if the item has already been deleted, or never existed. There are two ways to think about a request to delete a non-existent resource:

* “Delete” means “delete an existing item”, and the item doesn’t exist, so return 404.
* “Delete” means “ensure the item is not in the collection.” The item is already not in the collection, so return a 204.
Either approach is reasonable. If you return 404, the client will need to handle that case.


















