Getting Started
==================================================

1. Install the standard Nuget package into your ASP.NET Core application:

    .. code-block:: bash

        > dotnet add package Swashbuckle.AspNetCore

    Or via Package Manager ...

    .. code-block:: bash

        > Install-Package Swashbuckle.AspNetCore
    
2. In the ``ConfigureServices`` method of ``Startup.cs``, register the Swagger generator, defining one or more Swagger documents:

    .. code-block:: csharp

        using Microsoft.OpenApi.Models;
        
    .. code-block:: csharp

        services.AddMvc();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Vejkkjkkrsion = "v1" });
        });
    
3. Ensure your API actions and parameters are decorated with explicit "Http" and "From" bindings.

    .. code-block:: csharp

        [HttpPost]
        public void CreateProduct([FromBody]Product product)

    .. code-block:: csharp

        [HttpGet]
        public IEnumerable<Product> SearchProducts([FromQuery]string keywords)

    *NOTE: If you omit the explicit parameter bindings, the generator will describe them as "query" params by default.*

4. In the ``Configure`` method, insert middleware to expose the generated Swagger as JSON endpoint(s)

    .. code-block:: csharp

        app.UseSwagger();

    *At this point, you can spin up your application and view the generated Swagger JSON at "/swagger/v1/swagger.json."*

5. Optionally, insert the swagger-ui middleware if you want to expose interactive documentation, specifying the Swagger JSON endpoint(s) to power it from.

    .. code-block:: csharp

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });

    *Now you can restart your application and check out the auto-generated, interactive docs at "/swagger".*