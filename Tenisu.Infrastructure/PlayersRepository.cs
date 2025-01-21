using Newtonsoft.Json;
using Tenisu.Domain;

namespace Tenisu.Infrastructure
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly string _connectionString;
        public PlayersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Player GetPlayerById(int playerId)
        {
            try
            {
                using StreamReader reader = new(_connectionString);
                var json = reader.ReadToEnd();
                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(json);

                Player player = rootObject.Players
                    .Where(p => p.Id == playerId)
                    .FirstOrDefault();

                return player;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Player> GetPlayers()
        {
            try
            {
                using StreamReader reader = new(_connectionString);
                var json = reader.ReadToEnd();
                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(json);

                List<Player> players = rootObject.Players;

                return players;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

public class RootObject
{
    public List<Player> Players { get; set; }
}