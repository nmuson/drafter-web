using System;
using System.Collections.Generic;

namespace DrafterCf.Models
{
    public class Draft
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public int LeagueId { get; set; }
        public int Round { get; set; }

        public virtual League League { get; set; }
        public virtual ICollection<DraftPick> DraftPicks { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}