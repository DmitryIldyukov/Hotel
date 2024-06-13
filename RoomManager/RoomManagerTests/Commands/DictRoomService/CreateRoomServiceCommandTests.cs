using CommonLibrary.Helpers;
using Microsoft.EntityFrameworkCore;
using RoomManager.Application.Commands.DictRoomService;
using RoomManager.Application.Handlers;
using RoomManager.Application.Services.Dicts.DictRoomService;
using RoomManager.Domain.Exceptions;
using RoomManagerTests.Common;

namespace RoomManagerTests.Commands.DictRoomService;

public class CreateRoomServiceCommandTests : TestCommandBase
{
    [Fact]
    public async Task CreateRoomServiceCommandHandler_Success()
    {
        // Arrange
        var handler = new RoomServiceCommandHandler(_context, new DictRoomServiceMapper());
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

    [Fact]
    public async Task CreateRoomServiceCommandHandler_SameNames()
    {
        // Arrange
        var handler = new RoomServiceCommandHandler(_context, new DictRoomServiceMapper());
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
        // Arrange
        var handler = new RoomServiceCommandHandler(_context, new DictRoomServiceMapper());
        string name = RandomString.GetRandomString(5);
        int serialNumber = serialNum;
        
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(new CreateRoomServiceCommand { Name = name, SerialNumber = serialNumber }, CancellationToken.None));
    }

    [Fact]
    public async Task GetDeletedRoomServices()
    {
        // Arrange
        var handler = new RoomServiceCommandHandler(_context, new DictRoomServiceMapper());
        var roomService = _context.DictRoomServices.Add(
            new RoomManager.Domain.Entities.Dicts.DictRoomService(RandomString.GetRandomString(5))).Entity;
        var roomServiceId = roomService.Id;
        roomService.IsDeleted = true;
        await _context.SaveChangesAsync();
       
        // Act
        var roomServices = await handler.Handle(new GetAllRoomServiceCommand(), CancellationToken.None);
        
        // Assert
        Assert.Null(roomServices.FirstOrDefault(_ => _.Id == roomServiceId));
    }
}