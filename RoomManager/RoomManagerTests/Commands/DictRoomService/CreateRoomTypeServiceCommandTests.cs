using Microsoft.EntityFrameworkCore;
using RoomManager.Application.Commands.DictRoomService;
using RoomManagerTests.Common;

namespace RoomManagerTests.Commands.DictRoomService;

public class CreateRoomTypeServiceCommandTests : TestCommandBase
{
    [Fact]
    public async Task CreateRoomTypeServiceCommandHandler_Success()
    {
        // Arrage
        var handler = new CreateRoomTypeServiceCommandHandler(_context);
        string name = "room type service name";
        int serialNumber = 1;
        
        // Act
        var dictRoomTypeServiceId = await handler.Handle(
            new CreateRoomTypeServiceCommand
            {
                Name = name,
                SerialNumber = serialNumber,
            },
            CancellationToken.None
        );

        Assert.NotNull(
            await _context.DictRoomServices.SingleOrDefaultAsync(drs =>
                drs.Id == dictRoomTypeServiceId && drs.Name == name && drs.SerialNumber == serialNumber)
        );
    }
}