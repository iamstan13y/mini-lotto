using Microsoft.EntityFrameworkCore;
using MiniLotto.API.Models.Data;

namespace MiniLotto.API.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Player> Players { get; set; }
}