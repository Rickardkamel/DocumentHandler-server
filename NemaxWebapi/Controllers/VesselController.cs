using System.Collections.Generic;
using System.Web.Http;
using Business_Logic.Handlers;
using Contracts;

namespace CompanyWebapi.Controllers
{
    public class VesselController : ApiController
    {
        private readonly VesselHandler _vesselHandler;

        public VesselController()
        {
            _vesselHandler = new VesselHandler();
        }

        [HttpGet]
        public IEnumerable<VesselContract> Get()
        {
            return _vesselHandler.Get();
        }
    }
}
