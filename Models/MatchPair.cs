namespace SkillMatchAPI.Models
{
    public class MatchPair
    {
        public required User UserA { get; set; }
        public required User UserB { get; set; }
        public required string SkillExchange { get; set; } // e.g., "React <-> C#"
    }
}
