using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Highway.Data;

namespace Data.Queries
{
    public class TalkTitles : Query<Talk, string>
    {
        public TalkTitles()
        {
            Selector = c => c.AsQueryable<Talk>();

            Projector = talks => talks.Select(x => x.Title);
        }
    }
}
