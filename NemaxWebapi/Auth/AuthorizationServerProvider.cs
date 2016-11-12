using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Business_Logic.Handlers;
using Contracts;

namespace CompanyWebapi.Auth
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

        private UserContract _user;
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var accountHandler = new AccountHandler();

            var user = accountHandler.Login(new LoginContract
            {
                Username = context.UserName,
                Password = context.Password
            });

            if (user != null)
            {
                _user = user;
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));

                context.Validated(identity);
            }
            else
            {
                context.SetError("Failed to validate user.");
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            context.Properties.Dictionary.Add(new KeyValuePair<string, string>("userId", _user.Id.ToString()));
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
    }
}