using Microsoft.EntityFrameworkCore;
using MiniLotto.API.Models.Data;
using MiniLotto.API.Models.Local;

namespace MiniLotto.API.Models.Repository;

public class PlayerRepository : IPlayerRepository
{
    private readonly AppDbContext _context;

    public PlayerRepository(AppDbContext context) => _context = context;
    
    public async Task<Result<Player>> AddPlayerAsync(Player player)
    {
        try
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            
            return new Result<Player>(player);
        }
        catch (Exception ex)
        {
            return new Result<Player>(false, ex.Message);
        }
    }

    public async Task<Result<IEnumerable<Player>>> GetAllPlayersAsync()
    {
        return new Result<IEnumerable<Player>>(await _context.Players.ToListAsync());
    }

    public async Task<Result<Player>> GetPlayerAsync(int id)
    {
        try
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null) return new Result<Player>(false, "Player not found");
            
            return new Result<Player>(player);
        }
        catch (Exception ex)
        {
            return new Result<Player>(false, ex.Message);
        }
       
    }
}