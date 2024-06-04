using Microsoft.EntityFrameworkCore;
using RoomManager.Domain.Entities.Dicts;
using RoomManager.Infrastructure.Data;

namespace RoomManagerTests.Common;

public class RoomManagerContextFactory
{
    public static RoomManagerDbContext Create()
    {
        var options = new DbContextOptionsBuilder<RoomManagerDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new RoomManagerDbContext(options);

        context.Database.EnsureCreated();
        
        context.DictRoomServices.AddRange(
            new DictRoomService("DictRoomService1", 1) { Id = Guid.Parse("79d57ef1-66de-4fa8-8a76-123f53492a16")},
            new DictRoomService("DictRoomService2", 2) {Id = Guid.Parse("19d58cf7-6023-421a-9443-95564bb4260b")},
            new DictRoomService("DictRoomService3", 3) {Id = Guid.Parse("bafe3d48-7f9f-4b67-8ee5-767b5b55321d")}
        );

        context.SaveChanges();
        return context;
    }

    public static void Destroy(RoomManagerDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}