using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EgitimIdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
                new ApiResource("resource_api_1"){ Scopes={ "api1.read" , "api1.write", "api1.update" } ,
                ApiSecrets=new[]{new Secret("secretapi1".Sha256())}
                },
                new ApiResource("resource_api_2"){ Scopes={ "api2.read" , "api2.write", "api2.update" },
                ApiSecrets=new[]{new Secret("secretapi2".Sha256())}
                }
            };
        }
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope> {
                new ApiScope("api1.read","API 1 için okuma izni"),
                new ApiScope("api1.write","API 1 için yazma izni"),
                new ApiScope("api1.update","API 1 için güncelleme izni"),


                new ApiScope("api2.read","API 2 için okuma izni"),
                new ApiScope("api2.write","API 2 için yazma izni"),
                new ApiScope("api2.update","API 2 için güncelleme izni"),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client> {
               new  Client{
                   ClientId="Client1",
                   ClientName = "Client 1 App",
                   ClientSecrets=new[]{ new Secret("secret".Sha256())},
                   AllowedGrantTypes= GrantTypes.ClientCredentials,
                   AllowedScopes= {"api1.read" }

               },
               new  Client{
                   ClientId="Client2",
                   ClientName = "Client 2 App",
                   ClientSecrets=new[]{ new Secret("secret".Sha256())},
                   AllowedGrantTypes= GrantTypes.ClientCredentials,
                   AllowedScopes= {"api1.read","api2.write", "api2.update","api1.update" }
               },
                 new  Client{
                   ClientId="Client1-Mvc",
                   ClientName = "Client1-Mvc App",
                   RequirePkce=false, // uygulamam serverside olduğudan false
                   ClientSecrets=new[]{ new Secret("secret".Sha256())},
                   AllowedGrantTypes= GrantTypes.Hybrid,
                   RedirectUris=new List<string>{ "https://localhost:5006/signin-oidc" },//sign-in otomatik oluşur. openid connect kullandığımızdan
                   PostLogoutRedirectUris=new List<string>{ "https://localhost:5006/signout-callback-oidc" },
                   AllowedScopes= { IdentityServerConstants.StandardScopes.OpenId,
                                    IdentityServerConstants.StandardScopes.Profile ,

                                    "api1.read",
                                    IdentityServerConstants.StandardScopes.OfflineAccess, // refresh token almak için gerekiyor. startup.da scope lara da eklemek lazım.
                                    "CountryAndCity"
                                   }, //hangi yetkilerim var
                   AccessTokenLifetime=2*60*60, // access token ömrü
                   AllowOfflineAccess=true, // refresh token yayacak anlamına gelir.
                   RefreshTokenUsage= TokenUsage.ReUse, // teksefer mi yoksa devam lı üretilsin?
                   RefreshTokenExpiration=TokenExpiration.Absolute, // sling erişim olduğunda bi 15 dk daha atar. absolute kesin 5 gün sonra biter.
                   AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds // 60 gün sonra bitsin refresh tokenımız.

               }

            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>() {
            new IdentityResources.OpenId(), //subId
            new IdentityResources.Profile(),// https://developer.okta.com/blog/2017/07/25/oidc-primer-part-1
            //new IdentityResource(){ Name= "CountryAndCity",DisplayName="Country",Description="Ülke ve şehir bilgisi", UserClaims=new[]{"country","city" } }//ekstra eklemek istediklerimiz
            };
        }
        public static IEnumerable<TestUser> GetUsers()
        {
            return new List<TestUser>() {
            new TestUser{
                SubjectId="1",
                Username="kubraakben",
                Password="password",
                Claims=new List<Claim>{ new Claim("given_name","kubra"), new Claim("family_name","akben") ,
               // new Claim("country","TR"),
               // new Claim("city","İstanbul"),
                }
            },

            new TestUser{
                SubjectId="2",
                Username="canyaman",
                Password="password",
                Claims=new List<Claim>{ new Claim("given_name","can"), new Claim("family_name","yaman") }
            },
            };
        }
    }
}

