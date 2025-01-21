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
        private readonly string _pathToFile;
        private readonly IPlayersRepository _playersRepository;
        public PlayersController(IConfiguration configuration, IPlayersRepository playersRepository)
        {
            _pathToFile = configuration.GetConnectionString("PlayersDb");
            _playersRepository = playersRepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllPlayers()
        {
            IEnumerable<Player> players = _playersRepository.GetPlayers();
            var orderedPlayers = players.OrderBy(x => x.Data.Rank);
            return Ok(orderedPlayers);
        }

        [HttpGet("{playerid}")]
        public async Task<IActionResult> GetPlayerById([FromRoute]int playerid)
        {
            Player player = _playersRepository.GetPlayerById(playerid);
            return Ok(player);
        }
    }
}