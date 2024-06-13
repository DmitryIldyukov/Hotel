using MediatR;
using Microsoft.EntityFrameworkCore;
using RoomManager.Application.Commands.DictRoomService;
using RoomManager.Application.Services.Dicts.DictRoomService;
using RoomManager.Domain.DTOs.DictRoomService;
using RoomManager.Domain.Exceptions;
using RoomManager.Infrastructure.Data;

namespace RoomManager.Application.Handlers;

public class RoomServiceCommandHandler : 
    IRequestHandler<CreateRoomServiceCommand, Guid>, 
    IRequestHandler<GetAllRoomServiceCommand, IEnumerable<DictRoomServiceGetDto>>,
    IRequestHandler<EditRoomTypeServiceCommand, DictRoomServiceGetDto>,
    IRequestHandler<DeleteRoomTypeServiceCommand, Guid>
{
    private readonly RoomManagerDbContext _db;
    private readonly IDictRoomServiceMapper _mapper;

    public RoomServiceCommandHandler(RoomManagerDbContext db, IDictRoomServiceMapper mapper) => 
        (_db, _mapper) = (db, mapper);
    
    public async Task<Guid> Handle(CreateRoomServiceCommand request, CancellationToken cancellationToken)
    {
        var isRoomServiceExist = _db.DictRoomServices.Any(_ => !_.IsDeleted && _.Name.ToLower().Trim() == request.Name.ToLower().Trim());

        if (isRoomServiceExist) 
            throw new RecordAlreadyExist($"Услуга с названием {request.Name} уже существует");

        if (request.SerialNumber <= 0)
            throw new ArgumentException("Порядковый номер не может быть меньше 1");

        var roomService = new Domain.Entities.Dicts.DictRoomService(name: request.Name, serialNumber: request.SerialNumber);

        _db.Add(roomService);
        
        await _db.SaveChangesAsync(cancellationToken);

        return roomService.Id;
    }

    public async Task<IEnumerable<DictRoomServiceGetDto>> Handle(GetAllRoomServiceCommand request, CancellationToken cancellationToken)
    {
        var roomServices = await _db.DictRoomServices.ToListAsync(cancellationToken);
        return roomServices.Select(_ => _mapper.Map(_)).ToList();
    }

    public async Task<DictRoomServiceGetDto> Handle(EditRoomTypeServiceCommand request, CancellationToken cancellationToken)
    {
        var roomService = await _db.DictRoomServices.FirstOrDefaultAsync(_ => _.Id == request.Id, cancellationToken)
                          ?? throw new RecordNotFound($"Запись с {request.Id} не найдена.");

        roomService.Name = request.Name;
        roomService.SerialNumber = request.SerialNumber;

        await _db.SaveChangesAsync(cancellationToken);
        return _mapper.Map(roomService);
    }

    public async Task<Guid> Handle(DeleteRoomTypeServiceCommand request, CancellationToken cancellationToken)
    {
        var roomService = await _db.DictRoomServices.FirstOrDefaultAsync(_ => _.Id == request.Id, cancellationToken)
                          ?? throw new RecordNotFound($"Запись с {request.Id} не найдена.");

        roomService.IsDeleted = true;
        await _db.SaveChangesAsync(cancellationToken);
        return roomService.Id;
    }
}