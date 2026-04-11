namespace SkillMatchAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string CanTeach { get; set; }
        public required string WantsToLearn { get; set; }
        public required string Dept { get; set; }
    }
}
