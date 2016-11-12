using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using CompanyWebapi.App_Start;
using CompanyWebapi.Auth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyWebapi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            WebApiConfig.Configure(app);
            ConfigureOAuth(app);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(355),
                Provider = new AuthorizationServerProvider(),
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}