using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business_Logic.Handlers;

namespace CompanyWebapi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly CustomerHandler _customerHandler;

        public CustomerController()
        {
            _customerHandler = new CustomerHandler();
        }

        [HttpGet]
        public IEnumerable<CustomerContract> Get()
        {
            return _customerHandler.Get();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var customer = _customerHandler.Get(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }
    }
}