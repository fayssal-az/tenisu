using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Tenisu.Domain;
using Tenisu.Infrastructure;
using Tenisu.Usecases;

namespace Tenisu.API.Controllers
{

    [Route("players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly string _pathToFile;
        private readonly IPlayersRepository _playersRepository;
        private readonly FetchPlayersStatsUC _fetchPlayersStatsUseCase;

        public PlayersController(IConfiguration configuration, IPlayersRepository playersRepository)
        {
            _pathToFile = configuration.GetConnectionString("PlayersDb");
            _playersRepository = playersRepository;
            _fetchPlayersStatsUseCase = new FetchPlayersStatsUC(_playersRepository);
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllPlayers()
        {
            IEnumerable<Player> players = await _playersRepository.GetPlayersAsync();
            var orderedPlayers = players.OrderBy(x => x.Data.Rank);
            return Ok(orderedPlayers);
        }

        [HttpGet("{playerid}")]
        public async Task<IActionResult> GetPlayerById([FromRoute]int playerid)
        {
            Player player = await _playersRepository.GetPlayerByIdAsync(playerid);
            return Ok(player);
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var stats = _fetchPlayersStatsUseCase.Execute();
            return Ok(stats);
        }
    }
}