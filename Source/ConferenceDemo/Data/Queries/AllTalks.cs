using Data.Entities;
using Highway.Data;

namespace Data.Queries
{
    public class AllTalks : Query<Talk>
    {
        public AllTalks()
        {
            ContextQuery = c => 
                c.AsQueryable<Talk>();
        }
    }
}
