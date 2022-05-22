namespace BlazorServerCRUD.Data;

public interface IGameService
{
    List<Game> Games {get; set;}
    Task LoadGames();
}