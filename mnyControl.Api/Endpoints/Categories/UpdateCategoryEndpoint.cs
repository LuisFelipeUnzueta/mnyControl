using mnyControl.Api.Common.Api;
using mnyControl.Core.Handlers;
using mnyControl.Core.Models;
using mnyControl.Core.Requests.Categories;
using mnyControl.Core.Responses;
using System.Security.Claims;

namespace mnyControl.Api.Endpoints.Categories
{
    public class UpdateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
            .WithName("Categories: Update")
            .WithSummary("Atualiza uma categoria")
            .WithDescription("Atualiza uma categoria")
            .WithOrder(2)
            .Produces<Response<Category?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user, 
            ICategoryHandler handler, 
            UpdateCategoryRequest request, 
            long id) 
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            request.Id = id;
            
            var result = await handler.UpdateAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
