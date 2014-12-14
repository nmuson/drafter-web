namespace DrafterCf.Models
{
    public class AgeMap
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public int LeagueId { get; set; }

        public virtual League League { get; set; }
    }
}
