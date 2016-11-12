using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Contracts;
using Business_Logic.Handlers;

namespace CompanyWebapi.Controllers
{
    public class AccountController : ApiController
    {
        AccountHandler _loginHandler = new AccountHandler();

        [AllowAnonymous]
        [Route("api/account/login")]
        public IHttpActionResult Login(LoginContract loginContract)
        {

            return Ok(_loginHandler.Login(loginContract));
        }

        [AllowAnonymous]
        [Route("api/account/register")]
        public IHttpActionResult Register()
        {
           //Implement Later

            return NotFound();
        }
    }
}
