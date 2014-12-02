using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    public class TalksController : ApiController
    {
        [HttpGet]
        [Route("api/talks")]
        public IHttpActionResult Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("api/talks/{id}")]
        public IHttpActionResult Get(int id)
        {
            throw new NotImplementedException();
        }

    }
}
