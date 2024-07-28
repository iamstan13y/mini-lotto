using Microsoft.EntityFrameworkCore;
using MiniLotto.API.Extensions;
using MiniLotto.API.Models.Data;
using MiniLotto.API.Models.Local;

namespace MiniLotto.API.Models.Repository;

public class PlayerRepository(AppDbContext context) : IPlayerRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Result<Player>> AddPlayerAsync(Player player)
    {
        try
        {
            var existingPlayer = await _context.Players.Include(u => u.NumberSets).FirstOrDefaultAsync(u => u.Name == player.Name);

            if (existingPlayer is not null)
                existingPlayer.NumberSets.AddRange(player.NumberSets);
            else
                await _context.Players.AddAsync(player);

            await _context.SaveChangesAsync();
            return new Result<Player>(player.RemoveCycles()!);

        }
        catch (Exception ex)
        {
            return new Result<Player>(false, ex.Message);
        }
    }

    public async Task<Result<IEnumerable<Player>>> GetAllPlayersAsync()
    {
        var players = await _context.Players
            .Include(x => x.NumberSets)
            .ToListAsync();

        return new Result<IEnumerable<Player>>(players.RemoveCycles());
    }

    public async Task<Result<Player>> GetPlayerAsync(string name)
    {
        try
        {
            var player = await _context
                .Players
                .Include(x => x.NumberSets)
                .FirstOrDefaultAsync(x => x.Name == name);

            if (player == null) return new Result<Player>(false, "Player not found");

            return new Result<Player>(player.RemoveCycles()!);
        }
        catch (Exception ex)
        {
            return new Result<Player>(false, ex.Message);
        }
    }
}