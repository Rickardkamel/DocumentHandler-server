using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business_Logic.Handlers;
using Contracts;

namespace CompanyWebapi.Controllers
{
    public class InfoFlexCustomerController : ApiController
    {
        private readonly FlexCustomerHandler _flexCustomerHandler;

        public InfoFlexCustomerController()
        {
            _flexCustomerHandler = new FlexCustomerHandler();
        }

        [HttpGet]
        public IEnumerable<InfoFlexCustomerContract> Get()
        {
            return _flexCustomerHandler.Get();
        }

        [HttpGet]
        public IHttpActionResult Get(string custNumber)
        {
            var customer = _flexCustomerHandler.Get(custNumber);
            if (customer == null) return NotFound();
            return Ok(customer);
        }
    }
}
