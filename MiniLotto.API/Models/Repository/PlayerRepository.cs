using MiniLotto.API.Models.Data;
using MiniLotto.API.Models.Local;

namespace MiniLotto.API.Models.Repository;

public class PlayerRepository : IPlayerRepository
{
    public Task<Result<Player>> AddPlayerAsync(Player player)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Player>> GetAllPlayersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Player> GetPlayerAsync(int id)
    {
        throw new NotImplementedException();
    }
}