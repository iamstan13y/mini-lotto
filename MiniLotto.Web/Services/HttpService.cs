using MiniLotto.Web.Extensions;
using MiniLotto.Web.Models.Data;
using MiniLotto.Web.Models.Local;

namespace MiniLotto.Web.Services;

public class HttpService(HttpClient client) : IHttpService
{
    private readonly HttpClient _client = client;

    public async Task<Result<Player>> AddPlayerAsync(PlayerRequest request)
    {
        var response = await _client.PostAsJson($"/api/v1/Player/add", request);
        return await response.ReadContentAs<Result<Player>>();
    }

    public Task<Result<IEnumerable<Player>>> GetAllPlayersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<Player>> GetPlayerAsync(string name)
    {
        throw new NotImplementedException();
    }
}