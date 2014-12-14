using System.Collections.Generic;

namespace DrafterCf.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AgeMap> AgeMaps { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }
        public virtual ICollection<Draft> Drafts { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
