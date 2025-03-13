using Microsoft.AspNetCore.Identity;
using mnyControl.Api.Common.Api;
using mnyControl.Api.Models;

namespace mnyControl.Api.Endpoints.Identity
{
    public class LogoutEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app
                .MapPost("/logout", HandleAsync)
                .RequireAuthorization();

        private static async Task<IResult> HandleAsync(SignInManager<User> signInManager)
        {
            await signInManager.SignOutAsync();
            return Results.Ok();
        }
    }
}
