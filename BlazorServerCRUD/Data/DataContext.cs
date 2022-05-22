using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
}