using Tenisu.Domain;

public interface IPlayersRepository
{
    public IEnumerable<Player> GetPlayers();
}