using System;

namespace DrafterCf.Models
{  
    public class Player
    {
        public int PlayerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public Nullable<double> DraftScore { get; set; }
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public Nullable<int> FamilyId { get; set; }
    
        public virtual Family Family { get; set; }
        public virtual League League { get; set; }
    }
}
