using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swashbuckle.AspNetCore.Newtonsoft
{
    public class NewtonsoftSchemaGenerator : SchemaGeneratorBase
    {
        public NewtonsoftSchemaGenerator(SchemaGeneratorOptions generatorOptions, JsonSerializerSettings serializerSettings)
            : base(generatorOptions)
        {
            var contractResolver = serializerSettings.ContractResolver ?? new DefaultContractResolver();

            AddHandler(new FileTypeHandler());
            AddHandler(new PolymorphicTypeHandler(generatorOptions, this));
            AddHandler(new NewtonsoftPrimitiveTypeHandler(contractResolver, serializerSettings));
            AddHandler(new NewtonsoftEnumHandler(contractResolver, serializerSettings));
            AddHandler(new NewtonsoftDictionaryHandler(contractResolver, serializerSettings, this));
            AddHandler(new NewtonsoftArrayHandler(contractResolver, serializerSettings, this));
            AddHandler(new NewtonsoftObjectHandler(generatorOptions, contractResolver, serializerSettings, this));
        }
    }
}
