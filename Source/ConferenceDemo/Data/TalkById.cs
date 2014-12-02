using System.Linq;
using Data.Entities;
using Highway.Data;

namespace Data
{
    public class TalkById : Scalar<Talk>
    {
        public TalkById(int id)
        {
            ContextQuery = c =>
                c.AsQueryable<Talk>()
                    .FirstOrDefault(x => x.Id == id);
        }
    }
}
