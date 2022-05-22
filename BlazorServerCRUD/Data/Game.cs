namespace BlazorServerCRUD.Data;

public class Game
{
    public int Id { get; set; }
    
    public string? Name { get; set; } = String.Empty;
    
    public string? Developer { get; set; } = String.Empty;
    
    public DateTime? Release { get; set; }
    
    
}