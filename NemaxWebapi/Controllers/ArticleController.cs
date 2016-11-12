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
    public class ArticleController : ApiController
    {
        private readonly ArticleHandler _articleHandler;

        public ArticleController()
        {
            _articleHandler = new ArticleHandler();
        }

        [HttpGet]
        public IEnumerable<ArticleContract> Get()
        {
            return _articleHandler.Get();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var article = _articleHandler.Get(id);
            if (article == null) return NotFound();
            return Ok(article);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!_articleHandler.Delete(id)) return BadRequest();

            
            return Ok();
        }
    }
}
