using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using StarCrossing.HybridApp.Data;
using System.Security.Claims;

namespace StarCrossing.HybridApp;

internal sealed class AuthStateProvider(StarCrossingDbContext dbContext) : AuthenticationStateProvider
{
    private Player? _player;

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            if (_player is null && await dbContext.Database.CanConnectAsync())
            {
                _player = await dbContext.Player.SingleAsync();
            }
        }
        catch(Exception ex)
        {

        }

        var identity = new ClaimsIdentity(_player is null ? null : "Local");
        var principal = new ClaimsPrincipal(identity);
        return new AuthenticationState(principal);
    }
}
