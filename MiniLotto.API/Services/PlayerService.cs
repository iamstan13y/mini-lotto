using MiniLotto.API.Models.Local;
using MiniLotto.API.Models.Repository;

namespace MiniLotto.API.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private static readonly Random _random = new();

    public PlayerService(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<Result<DrawResult>> RunDrawAsync()
    {
        var players = (await _playerRepository.GetAllPlayersAsync()).Data;
        var winningNumbers = GenerateWinningNumbers();

        var winners = players?
            .Where(u => u.NumberSets.Any(ns => ns.Numbers.Intersect(winningNumbers).Count() >= 3))
            .Select(u => u.Name)
            .Distinct()
            .ToList();

        return new Result<DrawResult>(new DrawResult
        {
            WinningNumbers = winningNumbers,
            Winners = winners
        });
    }

    private List<int> GenerateWinningNumbers()
    {
        var numbers = new List<int>();
        while (numbers.Count < 6)
        {
            int number = _random.Next(1, 13);
            if (!numbers.Contains(number))
            {
                numbers.Add(number);
            }
        }
        return numbers;
    }
}