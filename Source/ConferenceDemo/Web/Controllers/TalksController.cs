using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using Data.Commands;
using Data.Entities;
using Data.Mappings;
using Data.Queries;
using Highway.Data;

namespace Web.Controllers
{
    public class TalksController : ApiController
    {
        readonly IRepository _repository;
        public TalksController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/talks")]
        public IHttpActionResult GetAll()
        {
            var talks = _repository.Find(new AllTalks()).ToList();
            return Ok(talks);
        }

        [HttpGet]
        [Route("api/v2/talks")]
        public IHttpActionResult GetAllDefault()
        {
            var talks = _repository.Find(new FindAll<Talk>()).ToList();
            return Ok(talks);
        }

        [HttpGet]
        [Route("api/talks/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var talks = _repository.Find(new TalkById(id));
            return Ok(talks);
        }

        [HttpGet]
        [Route("api/v2/talks/{id}")]
        public IHttpActionResult GetByIdDefault(int id)
        {
            var talks = _repository.Find(new GetById<int, Talk>(id));
            return Ok(talks);
        }

        [HttpDelete]
        [Route("api/talks/{id}")]
        public IHttpActionResult DeleteTalk(int id)
        {
            _repository.Execute(new DeleteTalk(id));
            return Ok();
        }

        [HttpDelete]
        [Route("api/v2/talks/{id}")]
        public IHttpActionResult DeleteTalkAdvanced(int id)
        {
            _repository.Execute(new DeleteTalkAdvanced(id));
            return Ok();
        }

        [HttpGet]
        [Route("api/talks/titles")]
        public IHttpActionResult GetTalkTitles()
        {
            var titles = _repository.Find(new TalkTitles());
            return Ok(titles);
        }

    }
}
