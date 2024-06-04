using MediatR;

namespace RoomManager.Application.Commands.DictRoomService;

public class CreateRoomTypeServiceCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public int? SerialNumber { get; set; }
}