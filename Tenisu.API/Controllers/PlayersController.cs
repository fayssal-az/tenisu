using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Tenisu.Domain;
using Tenisu.Infrastructure;

namespace Tenisu.API.Controllers
{

    [Route("players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IConfiguration _config;
        public PlayersController(IConfiguration configuration)
        {
            _config = configuration;

        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllPlayers()
        {
            string str = _config.GetConnectionString("PlayersDb");
            PlayersRepository repo = new PlayersRepository(str);
            IEnumerable<Player> players = repo.GetPlayers();
            var orderedPlayers = players.OrderBy(x => x.Data.Rank);
            return Ok(orderedPlayers);
        }
    }
}