using System.Linq;
using Data.Queries;
using Highway.Data;

namespace Web.Models
{
    public class TalksModel
    {
        readonly IRepository _repository;

        public TalksModel(IRepository repository)
        {
            _repository = repository;
        }

        public TalkViewModel GetTalks(int speakerId)
        {
            var talks = _repository.Find(new TalksBySpeakerId(speakerId)).ToList();
            return new TalkViewModel
            {
                AcceptedTalks = talks.Where(x=> x.Accepted),
                SubmittedTalks = talks.Where(x=>!x.Accepted)
            };
        }
    }
}