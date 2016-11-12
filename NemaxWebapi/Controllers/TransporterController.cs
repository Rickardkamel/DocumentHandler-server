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
    public class TransporterController : ApiController
    {
        private readonly TransporterHandler _transporterHandler;

        public TransporterController()
        {
            _transporterHandler = new TransporterHandler();
        }

        [HttpGet]
        public IEnumerable<TransporterContract> Get()
        {
            return _transporterHandler.Get();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var transporter = _transporterHandler.Get(id);
            if (transporter == null) return NotFound();
            return Ok(transporter);
        }
    }
}
