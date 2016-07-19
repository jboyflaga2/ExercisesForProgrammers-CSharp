This tutorial is from https://docs.microsoft.com/en-us/dotnet/articles/core/tutorials/using-with-xplat-cli

NOTE to self: you have notes on a physical notebook for this exercise. It's in notebook #5.

(This is copiesd from the page of the URL above because the contents of that URL might change in the future.)
## 6. Testing your Console App
### 6.1 Update directory and create `global.json` file
#### a. Move any source of your existing project into a new src folder.

```
/Project
|__/src
```

#### b. Create a /test directory.
```
/Project
|__/src
|__/test
```

#### c. Create a new global.json file:
``` 
/Project
|__/src
|__/test
|__global.json
```

``` JSON
global.json:

{
   "projects": [
      "src", "test"
   ]
}
```

This file tells the build system that this is a multi-project system, which allows it to look for dependencies in more than just the current folder it happens to be executing in. This is important because it allows you to place a dependency on the code under test in your test project.


### 6.2 There are two new things to make sure you have in your test project:

1\. A correct project.json with the following:

* A reference to `xunit`
* A reference to `dotnet-test-xunit`
* A reference to the namespace corresponding to the code under test

2\. An Xunit test class.


`NewTypesTests/project.json:`

``` JSON
{
  "version": "1.0.0-*",
  "testRunner": "xunit",

  "dependencies": {
    "Microsoft.NETCore.App": {
      "type":"platform",
      "version": "1.0.0"
    },
    "xunit":"2.2.0-beta2-build3300",
    "dotnet-test-xunit": "2.2.0-preview2-build1029",
    "NewTypes": "1.0.0"
  },
  "frameworks": {
    "netcoreapp1.0": {
      "imports": [
        "dnxcore50",
        "portable-net45+win8" 
      ]
    }
  }
}
```

`PetTests.cs:`
``` C#
using System;
using Xunit;
using Pets;
public class PetTests
{
    [Fact]
    public void DogTalkToOwnerTest()
    {
        string expected = "Woof!";
        string actual = new Dog().TalkToOwner();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CatTalkToOwnerTest()
    {
        string expected = "Meow!";
        string actual = new Cat().TalkToOwner();

        Assert.Equal(expected, actual);
    }
}
```


### 6.3 Now you can run tests! The dotnet test command runs the test runner you have specified in your project. Make sure you start at the top-level directory.

``` 
$ dotnet restore
$ cd test/NewTypesTests
$ dotnet test
```