using MediatR;
using RoomManager.Domain.DTOs.DictRoomService;

namespace RoomManager.Application.Commands.DictRoomService;

public class EditRoomTypeServiceCommand : IRequest<DictRoomServiceGetDto>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int? SerialNumber { get; init; }
}