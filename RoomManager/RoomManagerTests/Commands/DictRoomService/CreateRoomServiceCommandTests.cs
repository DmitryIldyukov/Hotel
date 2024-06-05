using CommonLibrary.Helpers;
using Microsoft.EntityFrameworkCore;
using RoomManager.Application.Commands.DictRoomService;
using RoomManager.Domain.Exceptions;
using RoomManagerTests.Common;

namespace RoomManagerTests.Commands.DictRoomService;

public class CreateRoomServiceCommandTests : TestCommandBase
{
    [Fact]
    public async Task CreateRoomServiceCommandHandler_Success()
    {
        // Arrage
        var handler = new CreateRoomServiceCommandHandler(_context);
        string randStr = RandomString.GetRandomString(5);
        string name = randStr;
        int serialNumber = 1;
        
        // Act
        var dictRoomTypeServiceId = await handler.Handle(
            new CreateRoomServiceCommand
            {
                Name = name,
                SerialNumber = serialNumber,
            },
            CancellationToken.None
        );

        // Assert
        Assert.NotNull(
            await _context.DictRoomServices.SingleOrDefaultAsync(drs =>
                drs.Id == dictRoomTypeServiceId && drs.Name == name && drs.SerialNumber == serialNumber)
        );
    }

    public async Task CreateRoomServiceCommandHandler_SameNames()
    {
        // Arrage
        var handler = new CreateRoomServiceCommandHandler(_context);
        string randStr = RandomString.GetRandomString(5);
        string name = randStr;
        int serialNumber = 1;
        
        // Act & Assert
        await handler.Handle(
            new CreateRoomServiceCommand
            {
              Name = name,
              SerialNumber = serialNumber,
            },
            CancellationToken.None
        );
        
        await Assert.ThrowsAsync<RecordAlreadyExist>(async () => await handler.Handle(
            new CreateRoomServiceCommand
            {
                Name = name,
                SerialNumber = serialNumber,
            },
            CancellationToken.None
        ));
    }
    
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task CreateRoomServiceCommandHandler_BadSerialNumber(int serialNum)
    {
        // Arrage
        var handler = new CreateRoomServiceCommandHandler(_context);
        string name = RandomString.GetRandomString(5);
        int serialNumber = serialNum;
        
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(new CreateRoomServiceCommand { Name = name, SerialNumber = serialNumber }, CancellationToken.None));
    }
}