using Microsoft.EntityFrameworkCore;
using MovieApi.Data;

namespace MovieApi.Tests;

public class TestDatabase
{
    private readonly DbContextOptions<DatabaseContext> _options;
    public DatabaseContext Context;
    
    public TestDatabase(DbContextOptions<DatabaseContext> options)
    {
        _options = options;
        Context = new DatabaseContext(options);
    }

    public void Connect()
    {
        Connected(this, EventArgs.Empty);
    }

    public void Reconnect()
    {
        Context.Dispose();
        Context = new DatabaseContext(_options);
        Connected(this, EventArgs.Empty);
    }

    public void Disconnect()
    {
        Context.Dispose();
    }

    public event EventHandler Connected = null!;
}