// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace UpSchoolEcommerce.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource ( "Resource_Catalog" ) { Scopes={ "Catalog_FullPermission" } },
            //new ApiResource ( "Resource_Order" ) { Scopes={ "Order_FullPermission" } },
            //new ApiResource ( "Resource_Discount" ) { Scopes={ "Discount_FullPermission" } },
            //new ApiResource ( "Resource_Basket" ) { Scopes={ "Basket_FullPermission" } },
            //new ApiResource ( "Resource_Payment" ) { Scopes={ "Payment_FullPermission" } },
            new ApiResource ( "Resource_Photo" ) { Scopes={ "Photo_FullPermission" } },
            new ApiResource ( IdentityServerConstants.LocalApi.ScopeName )
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope  ( "Catalog_FullPermission","Kalalog API için tam yetkili erişim." ),
            //new ApiScope  ( "Order_FullPermission","Sipariş API için tam yetkili erişim." ),
            //new ApiScope  ( "Discount_FullPermission","İndirim API için tam yetkili erişim." ),
            //new ApiScope  ( "Basket_FullPermission","Sepet API için tam yetkili erişim." ),
            //new ApiScope  ( "Payment_FullPermission","Ödeme API için tam yetkili erişim." ),
            new ApiScope  ( "Photo_FullPermission","Fotoğraf API için tam yetkili erişim." ),
            new ApiScope  ( IdentityServerConstants.LocalApi.ScopeName )
        };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "mvcclient",
                    ClientName = "asp.netcoremvc",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "Catalog_FullPermission" , "Order_FullPermission", "Discount_FullPermission", "Basket_FullPermission", "Payment_FullPermission", "Photo_FullPermission", IdentityServerConstants.LocalApi.ScopeName }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    //ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "scope2" }
                },
            };
    }
}