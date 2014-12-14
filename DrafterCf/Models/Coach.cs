using System;
using System.Collections.Generic;

namespace DrafterCf.Models
{
    public enum CoachRole
    {
        None = 0,
        HC,
        AC,
        Third,
        Mgr
    }

    public class Coach
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public CoachRole Role { get; set; }
        public Nullable<int> FamilyId { get; set; }
        public Nullable<int> LeagueId { get; set; }

        public virtual Family Family { get; set; }
        public virtual League League { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
