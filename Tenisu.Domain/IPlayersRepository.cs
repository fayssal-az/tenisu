using Tenisu.Domain;

public interface IPlayersRepository
{
    Player GetPlayerById(int playerid);
    public IEnumerable<Player> GetPlayers();
}