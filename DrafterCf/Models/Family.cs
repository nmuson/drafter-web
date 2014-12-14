using System.Collections.Generic;

namespace DrafterCf.Models
{   
    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Coach> Coaches { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
