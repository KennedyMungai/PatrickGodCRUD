using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Data;

public class GameService : IGameService
{
    private readonly DataContext _context;

    public List<Game> Games { get; set; } = new List<Game>();

    public GameService(DataContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task LoadGames()
    {
        Games = await _context.Games.ToListAsync();
    }
}