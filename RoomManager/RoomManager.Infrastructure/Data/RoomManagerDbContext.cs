using Microsoft.EntityFrameworkCore;
using RoomManager.Domain.Entities.Dicts;
using RoomManager.Infrastructure.Data.ModelConfigurations.DictRoomServiceConfiguration;

namespace RoomManager.Infrastructure.Data;

public class RoomManagerDbContext : DbContext
{
    public RoomManagerDbContext(DbContextOptions<RoomManagerDbContext> options) : base(options) { }

    #region DbSets
    public DbSet<DictRoomService> DictRoomServices { get; init; }

    #endregion

    #region Configurations

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        new DictRoomServiceConfiguration().Configure(modelBuilder.Entity<DictRoomService>());
    }

    #endregion
}