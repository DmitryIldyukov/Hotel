using RoomManager.Infrastructure.Data;

namespace RoomManagerTests.Common;

public abstract class TestCommandBase : IDisposable
{
    protected readonly RoomManagerDbContext _context;

    public TestCommandBase() => 
        _context = RoomManagerContextFactory.Create();

    public void Dispose()
    {
        RoomManagerContextFactory.Destroy(_context);
    }
}