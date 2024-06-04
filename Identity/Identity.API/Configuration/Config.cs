using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Identity.API.Configuration;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new ApiResource(name: "RoomManagerAPI", displayName: "Room Manager Api", userClaims: new []
                { JwtClaimTypes.Name })
            {
                Scopes = {"RoomManagerAPI"}
            }
        };
    
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("RoomManagerAPI", "Room Manager Api")
        };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>()
        {
            new Client()
            {
                ClientId = "room-manager-api",
                ClientName = "Room Manager Web",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                RedirectUris =
                {
                    "http://.../signin-oidc"  
                },
                AllowedCorsOrigins =
                {
                    "http://..."
                },
                PostLogoutRedirectUris =
                {
                    "http://.../signout-oidc"
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "RoomManagerAPI"
                },
                AllowAccessTokensViaBrowser = true
            }
        };
}