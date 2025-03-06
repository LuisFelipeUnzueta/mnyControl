﻿using mnyControl.Api.Common.Api;
using mnyControl.Core.Handlers;
using mnyControl.Core.Models;
using mnyControl.Core.Requests.Transactions;
using mnyControl.Core.Responses;
using System.Security.Claims;

namespace mnyControl.Api.Endpoints.Transactions
{
    public class DeleteTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
                .WithName("Transactions: Delete")
                .WithSummary("Exclui uma transação")
                .WithDescription("Exclui uma transação")
                .WithOrder(3)
                .Produces<Response<Transaction?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ITransactionHandler handler,
            long id)
        {
            var request = new DeleteTransactionRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
