using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Mapping;
using MovieApi.Tests.SeedData;
using NUnit.Framework;

namespace MovieApi.Tests;

public abstract class BaseSetup
{
    private SqliteConnection _dbConnection;
    
    protected IMapper Mapper;
    protected TestDatabase Database;

    [SetUp]
    public void Setup()
    {
        // Auto mapper set up
        var mapperConfig = new MapperConfiguration(mapConfig =>
        {
            mapConfig.AddProfile<AutoMapperProfile>();
        });
        Mapper = mapperConfig.CreateMapper();
        
        // Database set up
        _dbConnection = new SqliteConnection("DataSource=:memory:");
        _dbConnection.Open();

        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseSqlite(_dbConnection)
            .EnableSensitiveDataLogging()
            .Options;

        using (var context = new DatabaseContext(options))
        {
            context.Database.EnsureCreated();

            // SEED DB
            context.AddRange(Movies.SeedData);
            
            context.SaveChanges();
        }

        Database = new TestDatabase(options);
        Database.Connected += Connected;
        
        // once event handler has been initialised with service set up then invoke set up
        Database.Connect();
    }
    
    [TearDown]
    public void TearDown()
    {
        Database.Disconnect();
    }
    
    private void Connected(object? sender, EventArgs e)
    {
        SetUp(Database.Context);
    }

    protected abstract void SetUp(DatabaseContext databaseContext);
}