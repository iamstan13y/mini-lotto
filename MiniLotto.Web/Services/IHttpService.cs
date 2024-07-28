using MiniLotto.Web.Models.Data;
using MiniLotto.Web.Models.Local;

namespace MiniLotto.Web.Services;

public interface IHttpService
{
    Task<Result<Player>> AddPlayerAsync(PlayerRequest request);
    Task<Result<Player>> GetPlayerAsync(string name);
    Task<Result<IEnumerable<Player>>> GetAllPlayersAsync();
}