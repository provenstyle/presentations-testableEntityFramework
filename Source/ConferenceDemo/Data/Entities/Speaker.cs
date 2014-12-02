using System.Collections.Generic;

namespace Data.Entities
{
    public class Speaker: Entity
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public ICollection<Talk> Talks { get; set; }
    }
}
