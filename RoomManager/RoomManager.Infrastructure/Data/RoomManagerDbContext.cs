using Microsoft.EntityFrameworkCore;
using RoomManager.Domain.Entities.Dicts;

namespace RoomManager.Infrastructure.Data;

public class RoomManagerDbContext : DbContext
{
    public RoomManagerDbContext(DbContextOptions<RoomManagerDbContext> options) : base(options) { }

    #region DbSets
    public DbSet<DictRoomService> DictRoomServices { get; set; }

    #endregion
}