﻿using System;
using System.Text.Json;
using Microsoft.OpenApi.Models;
using Xunit;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swashbuckle.AspNetCore.Annotations.Test
{
    public class AnnotationsSchemaFilterTests
    {
        private readonly IApiModelResolver _apiModelResolver;

        public AnnotationsSchemaFilterTests()
        {
            _apiModelResolver = new JsonApiModelResolver(new JsonSerializerOptions());
        }

        [Theory]
        [InlineData(typeof(SwaggerAnnotatedClass))]
        [InlineData(typeof(SwaggerAnnotatedStruct))]
        public void Apply_DelegatesToSpecifiedFilter_IfTypeDecoratedWithFilterAttribute(Type type)
        {
            var schema = new OpenApiSchema();
            var context = FilterContextFor(type);

            Subject().Apply(schema, context);

            Assert.NotEmpty(schema.Extensions);
        }

        private SchemaFilterContext FilterContextFor(Type type)
        {
            return new SchemaFilterContext(
                _apiModelResolver.ResolveApiModelFor(type),
                schemaRepository: null, // NA for test
                schemaGenerator: null // NA for test
            );
        }

        private AnnotationsSchemaFilter Subject()
        {
            return new AnnotationsSchemaFilter(null);
        }
    }
}