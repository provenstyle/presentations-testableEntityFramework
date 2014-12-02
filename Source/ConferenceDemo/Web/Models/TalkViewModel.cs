using System.Collections.Generic;
using Data.Entities;

namespace Web.Models
{
    public class TalkViewModel
    {
        public IEnumerable<Talk> SubmittedTalks { get; set; }
        public IEnumerable<Talk> AcceptedTalks { get; set; }
    }
}