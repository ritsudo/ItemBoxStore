using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ItemBoxStore.API.Swagger
{
    public class HideInDocsFilter : IDocumentFilter
    {

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (OpenApiPathItem path in swaggerDoc.Paths.Values)
            {
                path.Parameters = null;
            }
        }
    }
}
