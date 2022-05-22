using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;

namespace BlazorServerCRUD.Data;

public class GameService : IGameService
{
    private readonly DataContext _context;
    private readonly NavigationManager _navigationManager;

    public List<Game> Games { get; set; } = new List<Game>();

    public GameService(DataContext context, NavigationManager navigationManager)
    {
        _context = context;
        _navigationManager = navigationManager;
        _context.Database.EnsureCreated();
    }

    public async Task LoadGames()
    {
        Games = await _context.Games.ToListAsync();
    }

    public async Task CreateGame(Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        _navigationManager.NavigateTo("VideoGames");
    }

    public async Task<Game> GetSingleGame(int id)
    {
        var game = await _context.Games.FindAsync(id);

        if (game is null)
        {
            throw new Exception("No game here....");
        }

        return game;
    }

    public async Task UpdateGame(Game game, int id)
    {
        var dbGame = await _context.Games.FindAsync(id);

        if (dbGame is null)
        {
            throw new Exception("There is no game here...");
        }

        dbGame.Name = game.Name;
        dbGame.Id = game.Id;
        dbGame.Developer = game.Developer;
        dbGame.Release = game.Release;

        await _context.SaveChangesAsync();
        _navigationManager.NavigateTo("VideoGames");
    }

    public async Task DeleteGame(int id)
    {
        var dbGame = await _context.Games.FindAsync(id);

        if (dbGame is null)
        {
            throw new Exception("No game here...");
        }

        _context.Games.Remove(dbGame);
        await _context.SaveChangesAsync();
        _navigationManager.NavigateTo("VideoGames");
    }
}