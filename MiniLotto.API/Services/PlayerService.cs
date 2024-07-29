using MiniLotto.API.Models.Local;
using MiniLotto.API.Models.Repository;

namespace MiniLotto.API.Services;

public class PlayerService(IPlayerRepository playerRepository) : IPlayerService
{
    private readonly IPlayerRepository _playerRepository = playerRepository;
    private static readonly Random _random = new();

    public async Task<Result<DrawResult>> RunDrawAsync()
    {
        var players = (await _playerRepository.GetAllPlayersAsync()).Data;
        var winningNumbers = GenerateWinningNumbers();

        var winners = players?
            .Where(u => u.NumberSets.Any(ns => ns.Numbers.Intersect(winningNumbers).Count() >= 5))
            .Select(u => new WinnerDetail
            {
                Name = u.Name,
                WinningNumbers = u.NumberSets
                    .Where(ns => ns.Numbers.Intersect(winningNumbers).Count() >= 5)
                    .SelectMany(ns => ns.Numbers)
                    .Intersect(winningNumbers)
                    .ToList()
            })
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