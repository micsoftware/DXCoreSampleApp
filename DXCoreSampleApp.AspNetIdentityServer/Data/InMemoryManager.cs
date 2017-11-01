using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthorizationServer.IdSrv4
{
    public class InMemoryManger
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                new ApiResource("TextMarkettingApi", "Text Marketting API"),
                new ApiResource
                {
                    Name = "ecatalogapi",
                    UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Email, JwtClaimTypes.Role },

                    Scopes =
                    {
                        new Scope(){ Name = "api.full_access", Description = "Full access to API" },
                        new Scope() { Name = "api.read_only" , Description = "Readonly access to API"},
                        new Scope() {Name = IdentityServerConstants.StandardScopes.Email },
                        new Scope() {Name = IdentityServerConstants.StandardScopes.Profile }
                    }
                }
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    ClientSecrets = new [] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes =  GrantTypes.ImplicitAndClientCredentials,
                    AllowedScopes =
                    {
                        "TextMarkettingApi",
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "api.read_only"
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "TextMarkettingApi",
                    UserClaims = new [] { "name", "email", "status" },
                    Enabled = true
                }
            };
        }

        public static IEnumerable<TestUser> Users()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "jdoe@email.com",
                    Password = "123456",
                    IsActive = true
                }
            };
        }
    }
}
