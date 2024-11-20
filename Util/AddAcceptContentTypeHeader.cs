using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FilmVault.Util;

public class AddAcceptContentTypeHeader : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Add Accept header
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Accept",
            In = ParameterLocation.Header,
            Required = false,
            Description = "Set the desired response format (e.g., application/json, application/xml)",
            Schema = new OpenApiSchema { Type = "string" }
        });

        // Add Content-Type header (for request bodies)
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Content-Type",
            In = ParameterLocation.Header,
            Required = false,
            Description = "Set the content type of the request body (e.g., application/json, application/xml)",
            Schema = new OpenApiSchema { Type = "string" }
        });
    }
}