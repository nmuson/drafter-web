using System.Collections.Generic;

namespace DrafterCf.Models
{   
    public class Team
    {
        public int Id { get; set; }
        public string Sponsor { get; set; }
        public string Name { get; set; }
        public int PickSlot { get; set; }
        public int DraftId { get; set; }

        public virtual ICollection<DraftPick> DraftPicks { get; set; }
        public virtual Draft Draft { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }
    }
}
