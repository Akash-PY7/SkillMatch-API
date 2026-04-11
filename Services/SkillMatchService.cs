using SkillMatchAPI.Models;

namespace SkillMatchAPI.Services
{
    public interface ISkillMatchService
    {
        List<User> GetAllUsers();
        List<MatchPair> FindPerfectMatches();
    }

    public class SkillMatchService : ISkillMatchService
    {
        private static readonly List<User> Users = new()
        {
            new User { UserId = 1, Name = "Elena", CanTeach = "React", WantsToLearn = "C#", Dept = "Frontend" },
            new User { UserId = 2, Name = "Marcus", CanTeach = "C#", WantsToLearn = "React", Dept = "Backend" },
            new User { UserId = 3, Name = "Sarah", CanTeach = "SQL", WantsToLearn = "Python", Dept = "Data" },
            new User { UserId = 4, Name = "David", CanTeach = "Python", WantsToLearn = "SQL", Dept = "DevOps" }
        };

        public List<User> GetAllUsers()
        {
            return Users;
        }

        public List<MatchPair> FindPerfectMatches()
        {
            return Users
                .SelectMany(a => Users, (a, b) => (a, b))
                .Where(pair => pair.a.UserId < pair.b.UserId)
                .Where(pair => pair.a.CanTeach == pair.b.WantsToLearn && pair.b.CanTeach == pair.a.WantsToLearn)
                .Select(pair => new MatchPair
                {
                    UserA = pair.a,
                    UserB = pair.b,
                    SkillExchange = $"{pair.a.CanTeach} <-> {pair.b.CanTeach}"
                })
                .ToList();
        }
    }
}
