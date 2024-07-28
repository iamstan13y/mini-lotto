using MiniLotto.API.Models.Local;

namespace MiniLotto.API.Services;

public interface IPlayerService
{
    Task<Result<DrawResult>> RunDrawAsync();
}