using MiniLotto.API.Models.Data;
using MiniLotto.API.Models.Local;

namespace MiniLotto.API.Models.Repository;

public interface IPlayerRepository
{
    Task<Result<Player>> AddPlayerAsync(Player player);
    Task<Player> GetPlayerAsync(int id);
    Task<IEnumerable<Player>> GetAllPlayersAsync();
}