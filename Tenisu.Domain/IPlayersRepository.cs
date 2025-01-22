using Tenisu.Domain;

public interface IPlayersRepository
{
    Task<Player> GetPlayerByIdAsync(int playerid);
    Task <IEnumerable<Player>> GetPlayersAsync();
}