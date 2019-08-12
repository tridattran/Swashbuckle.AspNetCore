Describing Responses
========================

By default, Swashbuckle will generate a "200" response for *all* operations. Additionally, if the action returns a response DTO then this will be used to generate a "schema" for the response body. For example, given the following action ...

    .. literalinclude:: ..\..\..\test\WebSites\GettingStarted\Controllers\ProductsController.cs
        :language: csharp
        :start-at: [HttpGet("{id}")]
        :lines: 1-2
        :dedent: 8
        
Swashbuckle will generate the following response metadata:

    .. code-block:: javascript

        responses: {
          200: {
            description: "Success",
            content: {
              "application/json": {
                schema: {
                  $ref: "#/components/schemas/Product"
                }
              }
            }
          }
        }

Explicit Responses
------------------

If you need to specify a different status code and/or additional responses, or your actions return ``IActionResult`` instead of a response DTO, you can describe responses explicitly with the ``ProducesResponseType`` attribute that ships with ASP.NET Core. For example ...

    .. literalinclude:: ..\..\..\test\WebSites\GettingStarted\Controllers\OrdersController.cs
        :language: csharp
        :start-at: [HttpPost]
        :lines: 1-5
        :dedent: 8

Will result in the following response metadata:

    .. code-block:: javascript

        responses: {
          201: {
            description: "Success",
            content: {
              "application/json": {
                schema: {
                  type: "integer",
                  format: "int32"
                }
              }
            }
          },
          400: {
            description: "Bad Request",
            content: {
              "application/json": {
                schema: {
                  additionalProperties: {
                    type: "string"    
                  }
                }
              }
            }
          },
          500: {
            description: "Server Error"
          }
        }

**NOTE:** With this approach, you MUST provide an explicit response for *every* response code you'd like to document. That is, the default "200" response will NOT be automatically generated if the action is decorated with one or more ``ProducesResponseType`` attributes.

Default Response
----------------

Sometimes, an operation can return multiple errors with different HTTP status codes, but all of them have the same response structure. Rather than providing an explicit repsonse for each one, you can use the ``ProducesDefaultResponseType`` attribute instead:

    .. literalinclude:: ..\..\..\test\WebSites\GettingStarted\Controllers\OrdersController.cs
        :language: csharp
        :start-at: [HttpDelete("{id}")]
        :lines: 1-4
        :dedent: 8

Results in:

    .. code-block:: javascript

        responses: {
          201: {
            description: "Success",
            content: {
              "application/json": {
                schema: {
                  type: "integer",
                  format: "int32"
                }
              }
            }
          },
          default: {
            description: "Unexpected Error",
            content: {
              "application/json": {
                schema: {
                  additionalProperties: {
                    type: "string"    
                  }
                }
              }
            }
          },
        }
