using Microsoft.AspNetCore.Mvc;
using mnyControl.Api.Common.Api;
using mnyControl.Core.Handlers;
using mnyControl.Core.Models;
using mnyControl.Core.Requests.Categories;
using mnyControl.Core.Responses;
using mnyControl.Core;
using System.Security.Claims;

namespace mnyControl.Api.Endpoints.Categories
{
    public class GetAllCategoriesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("Categories: Get All")
                .WithSummary("Recupera todas as categorias")
                .WithDescription("Recupera todas as categorias")
                .WithOrder(5)
                .Produces<PagedResponse<List<Category>?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ICategoryHandler handler,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllCategoriesRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
