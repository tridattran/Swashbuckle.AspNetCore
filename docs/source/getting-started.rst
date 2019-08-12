Getting Started
==================================================

1. Install the standard Nuget package into your ASP.NET Core application:

    .. code-block:: bash

        > dotnet add package Swashbuckle.AspNetCore

    or via Package Manager ...

    .. code-block:: bash

        > Install-Package Swashbuckle.AspNetCore
    
2. In the ``ConfigureServices`` method of ``Startup.cs``, register the Swagger generator, defining one or more Swagger/OpenAPI documents:

    .. literalinclude:: ..\..\test\WebSites\GettingStarted\Startup.cs
        :language: csharp
        :start-at: AddSwaggerGen(
        :lines: 1-4
        :dedent: 12
    
3. Ensure your API actions and parameters are decorated with explicit "Http" and "From" bindings.

    .. literalinclude:: ..\..\test\WebSites\GettingStarted\Controllers\ProductsController.cs
        :language: csharp
        :start-at: [HttpPost]
        :lines: 1-2
        :dedent: 8

    .. literalinclude:: ..\..\test\WebSites\GettingStarted\Controllers\ProductsController.cs
        :language: csharp
        :start-at: [HttpGet]
        :lines: 1-2
        :dedent: 8

    *NOTE: If you omit the explicit parameter bindings, the generator will describe them as "query" params by default.*

4. In the ``Configure`` method, insert middleware to expose the generated Swagger as JSON endpoint(s)

    .. literalinclude:: ..\..\test\WebSites\GettingStarted\Startup.cs
        :language: csharp
        :start-at: UseSwagger(
        :lines: 1
        :dedent: 12

    *At this point, you can spin up your application and view the generated Swagger JSON at "/swagger/v1/swagger.json."*

5. Optionally, if you want to expose interactive documentation, insert the swagger-ui middleware, specifying the Swagger JSON endpoint(s) to power it from.

    .. literalinclude:: ..\..\test\WebSites\GettingStarted\Startup.cs
        :language: csharp
        :start-at: UseSwaggerUI(
        :lines: 1-4
        :dedent: 12

    *Now you can restart your application and check out the auto-generated, interactive docs at "/swagger".*