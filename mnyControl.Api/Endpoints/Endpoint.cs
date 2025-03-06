using mnyControl.Api.Common.Api;
using mnyControl.Api.Endpoints.Categories;
using mnyControl.Api.Endpoints.Transactions;

namespace mnyControl.Api.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            //tudo que faço aqui se aplica para todas as rotas
            var endpoints = app.MapGroup(prefix: "");

            endpoints.MapGroup("/")
           .WithTags("Health Check")
           .MapGet("/", () => new { message = "OK" });

            endpoints.MapGroup(prefix: "v1/categories")
                .WithTags("Categories")
                //.RequireAuthorization()
                .MapEndpoint<CreateCategoryEndpoint>()
                .MapEndpoint<UpdateCategoryEndpoint>()
                .MapEndpoint<DeleteCategoryEndpoint>()
                .MapEndpoint<GetCategoryByIdEndpoint>()
                .MapEndpoint<GetAllCategoriesEndpoint>();

            endpoints.MapGroup("v1/transactions")
           .WithTags("Transactions")
           .RequireAuthorization()
           .MapEndpoint<CreateTransactionEndpoint>()
           .MapEndpoint<UpdateTransactionEndpoint>()
           .MapEndpoint<DeleteTransactionEndpoint>()
           .MapEndpoint<GetTransactionByIdEndpoint>()
           .MapEndpoint<GetTransactionsByPeriodEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
