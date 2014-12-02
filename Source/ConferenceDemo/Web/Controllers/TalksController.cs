using System.Configuration;
using System.Web.Http;
using Data.Mappings;
using Highway.Data;

namespace Web.Controllers
{
    public class TalksController : ApiController
    {
        IRepository _repository;

        public TalksController()
        {
        }

        [HttpGet]
        [Route("api/talks")]
        public IHttpActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/v2/talks")]
        public IHttpActionResult GetAllHighwayDefault()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/talks/{id}")]
        public IHttpActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/v2/talks/{id}")]
        public IHttpActionResult GetByIdHighwayDefault(int id)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("api/talks/{id}")]
        public IHttpActionResult DeleteTalk(int id)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("api/v2/talks/{id}")]
        public IHttpActionResult DeleteTalkAdvanced(int id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/talks/titles")]
        public IHttpActionResult GetTalkTitles()
        {
            return Ok();
        }

    }
}
