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
    public class ReportController : ApiController
    {
        private readonly ReportHandler _reportHandler;

        public ReportController()
        {
            _reportHandler = new ReportHandler();
        }

        [HttpGet]
        public IEnumerable<ReportContract> Get()
        {
            return _reportHandler.Get();
        }
        
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var report = _reportHandler.Get(id);

            if (report == null) return NotFound();
            return Ok(report);
        }
       
        [HttpPost]
        public IHttpActionResult Post(ReportContract reportContract)
        {
            _reportHandler.Post(reportContract);
            return Ok();
        }

        [HttpPost]
        [Route("api/report/editReport")]
        public IHttpActionResult Edit(ReportContract reportContract)
        {
            //_reportHandler.EditReport(reportContract);
            return Ok();
        }

        [HttpGet]
        [Route("api/report/getlatestid")]
        public IHttpActionResult GetLatestId()
        {
            try
            {
                return Ok(_reportHandler.Get().Max(x => x.Id));
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("api/report/editReportRegion/{reportId}/{regionId}")]
        public IHttpActionResult EditReportRegion(int reportId, int regionId)
        {
            return Ok(_reportHandler.EditReportRegion(reportId, regionId));
        }


        [HttpGet]
        [Route("api/report/customerName/{customerName}/{fromHistory}")]
        public IHttpActionResult CustomerNameSearch(string customerName, int fromHistory)
        {
            return Ok(_reportHandler.GetReportsFromCustomerNameSearch(customerName, fromHistory));
        }

        [HttpGet]
        [Route("api/report/customerCity/{customerCity}/{fromHistory}")]
        public IHttpActionResult CustomerCitySearch(string customerCity, int fromHistory)
        {
            return Ok(_reportHandler.GetReportsFromCustomerCitySearch(customerCity, fromHistory));
        }

        [HttpGet]
        [Route("api/report/info/{info}/{fromHistory}")]
        public IHttpActionResult InfoSearch(string info, int fromHistory)
        {
            return Ok(_reportHandler.GetReportsFromInfoSearch(info, fromHistory));
        }

        [HttpGet]
        [Route("api/report/id/{id}/{fromHistory}")]
        public IHttpActionResult IdSearch(string id, int fromHistory)
        {
            return Ok(_reportHandler.GetReportsFromIdSearch(id, fromHistory));
        }

        [HttpGet]
        [Route("api/report/getReportWaste/{reportid}")]
        public ReportContract GetReportWaste(int reportId)
        {
            return _reportHandler.GetFromReport(reportId);

        }
    }
}
