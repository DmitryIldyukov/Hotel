using MediatR;
using RoomManager.Domain.Exceptions;
using RoomManager.Infrastructure.Data;

namespace RoomManager.Application.Commands.DictRoomService;

public class CreateRoomServiceCommandHandler : IRequestHandler<CreateRoomServiceCommand, Guid>
{
    private readonly RoomManagerDbContext _db;

    public CreateRoomServiceCommandHandler(RoomManagerDbContext db) => 
        _db = db;
    
    public async Task<Guid> Handle(CreateRoomServiceCommand request, CancellationToken cancellationToken)
    {
        var isRoomServiceExist = _db.DictRoomServices.Any(_ => !_.IsDeleted && _.Name.ToLower().Trim() == request.Name.ToLower().Trim());

        if (isRoomServiceExist) 
            throw new RecordAlreadyExist($"Услуга с названием {request.Name} уже существует");

        var roomService = new Domain.Entities.Dicts.DictRoomService(name: request.Name, serialNumber: request.SerialNumber);

        _db.Add(roomService);
        
        await _db.SaveChangesAsync(cancellationToken);

        return roomService.Id;
    }
}