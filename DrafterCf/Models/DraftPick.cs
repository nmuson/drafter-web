using System;

namespace DrafterCf.Models
{
    public class DraftPick
    {
        public int Id { get; set; }
        public int Pick { get; set; }
        public int DraftId { get; set; }
        public int Round { get; set; }
        public Nullable<int> TeamId { get; set; }
        public Nullable<int> PlayerId { get; set; }

        public virtual Draft Draft { get; set; }
        public virtual Player Player { get; set; }
        public virtual Team Team { get; set; }
    }
}
