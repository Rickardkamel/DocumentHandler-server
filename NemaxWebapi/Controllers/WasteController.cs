using Contracts;
using System.Collections.Generic;
using System.Web.Http;
using Business_Logic.Handlers;

namespace CompanyWebapi.Controllers
{
    public class WasteController : ApiController
    {

        private readonly FlexWasteHandler _wasteRepo = new FlexWasteHandler();

        [HttpGet]
        public IEnumerable<WasteContract> Get()
        {
            return _wasteRepo.Get();
        }

        [HttpGet]
        [Route("api/waste/{id}")]
        public IHttpActionResult Get(string id)
        {
            var waste = _wasteRepo.Get(id);

            if (waste == null) return NotFound();
            return Ok(waste);
        }
    }
}
