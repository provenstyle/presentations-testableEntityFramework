using System.Linq;
using Data.Entities;
using Highway.Data;

namespace Data.Queries
{
    public class TalksBySpeakerId : Query<Talk>
    {
        public TalksBySpeakerId(int speakerId)
        {
            ContextQuery = c => 
                c.AsQueryable<Talk>()
                    .Where(x => x.Speaker.Id == speakerId);
        }
    }
}