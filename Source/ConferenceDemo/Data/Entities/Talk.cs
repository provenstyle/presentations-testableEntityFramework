using System.Collections.Generic;

namespace Data.Entities
{
    public class Talk: Entity
    {
        public string Title { get; set; }
        public string Abstract { get; set; }
        public bool Accepted { get; set; }
        public Speaker Speaker { get; set; }
    }
}
