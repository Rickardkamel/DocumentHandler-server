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
    
    public class RegionController : ApiController
    {
        private RegionHandler _regionHandler = new RegionHandler();

        [HttpGet]
        public IEnumerable<RegionContract> Get()
        {
            return _regionHandler.Get().OrderBy(x => x.Name);
        }

        [HttpGet]
        [Route("api/region/{id}")]
        public RegionContract Get(int id)
        {
            return _regionHandler.Get(id);
        }

        [HttpPost]
        public IHttpActionResult Post(RegionContract regionContract)
        {
             return Ok(_regionHandler.Post(regionContract));
        }

        [HttpGet]
        [Route("api/region/detailed")]
        public IEnumerable<RegionContract> Detailed()
        {
            return _regionHandler.GetDetailedRegionContract().OrderByDescending(x => x.TotalPalletSpace).ThenBy(x => x.TotalReports).ThenBy(x => x.Name);
        }

        [HttpGet]
        [Route("api/region/reports/{id}")]
        public List<ReportContract> Reports(int id)
        {
            return _regionHandler.RegionReports(id);
        }
    }
}