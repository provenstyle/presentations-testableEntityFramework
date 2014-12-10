using System.Collections.Generic;
using System.Linq;
using Data.Entities;
using Highway.Data;
using Highway.Data.Contexts;
using Machine.Specifications;

// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToLambdaExpression
namespace DataTestsMspec
{
    public class when_querying_acceptedTalksBySpeaker
    {
        Establish context = () =>
        {
            _dataContext = new InMemoryDataContext();
            var speaker = new Speaker {Id = 7};
            _dataContext.Add(new Talk {Speaker = speaker, Accepted = true});
            _dataContext.Add(new Talk {Speaker = speaker, Accepted = false});
            _query = new AcceptedTalksBySpeaker(7);
        };

        Because of = () =>
        {
            _acceptedTalks = _query.Execute(_dataContext);
        };

        It should_only_return_accepted_talks = () => _acceptedTalks.Count().ShouldEqual(1);

        static AcceptedTalksBySpeaker _query;
        static InMemoryDataContext _dataContext;
        static IEnumerable<Talk> _acceptedTalks;
    }

    public class AcceptedTalksBySpeaker : Query<Talk>
    {
        public AcceptedTalksBySpeaker(int speakerId)
        {
            ContextQuery = c => c.AsQueryable<Talk>()
                .Where(x =>
                    x.Speaker.Id == speakerId &&
                    x.Accepted);
        }
    }
}