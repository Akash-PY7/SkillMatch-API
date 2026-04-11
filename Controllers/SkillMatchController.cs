using Microsoft.AspNetCore.Mvc;
using SkillMatchAPI.Models;
using SkillMatchAPI.Services;

namespace SkillMatchAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillMatchController : ControllerBase
    {
        private readonly ISkillMatchService _skillMatchService;

        public SkillMatchController(ISkillMatchService skillMatchService)
        {
            _skillMatchService = skillMatchService;
        }

        [HttpGet("users")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _skillMatchService.GetAllUsers();
            return Ok(new
            {
                success = true,
                count = users.Count,
                data = users
            });
        }

        [HttpGet("matches")]
        public ActionResult<IEnumerable<MatchPair>> GetPerfectMatches()
        {
            var matches = _skillMatchService.FindPerfectMatches();
            return Ok(new
            {
                success = true,
                totalMatches = matches.Count,
                data = matches
            });
        }

    }
}