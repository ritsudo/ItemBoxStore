using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Swagger
{
    public class ApiExplorerOnlyConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {

            bool hasHttpGet = action.Attributes.OfType<HttpGetAttribute>().Any();
            bool hasHttpPost = action.Attributes.OfType<HttpPostAttribute>().Any();
            bool hasHttpDelete = action.Attributes.OfType<HttpDeleteAttribute>().Any();
            bool hasHttpPut = action.Attributes.OfType<HttpPutAttribute>().Any();

            action.ApiExplorer.IsVisible = hasHttpGet || hasHttpPost || hasHttpDelete || hasHttpPut;

        }
    }
}
