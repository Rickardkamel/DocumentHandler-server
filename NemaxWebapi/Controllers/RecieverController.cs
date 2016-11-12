using System.Collections.Generic;
using System.Web.Http;
using Business_Logic.Handlers;
using Contracts;

namespace CompanyWebapi.Controllers
{
    public class RecieverController : ApiController
    {
        private readonly RecieverHandler _recieverHandler;

        public RecieverController()
        {
            _recieverHandler = new RecieverHandler();
        }

        [HttpGet]
        public IEnumerable<RecieverContract> Get()
        {
            return _recieverHandler.Get();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var reciever = _recieverHandler.Get(id);
            if (reciever == null) return NotFound();
            return Ok(reciever);
        }
    }
}
