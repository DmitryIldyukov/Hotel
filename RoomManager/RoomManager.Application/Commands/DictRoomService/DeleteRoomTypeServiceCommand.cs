using MediatR;

namespace RoomManager.Application.Commands.DictRoomService;

public class DeleteRoomTypeServiceCommand : IRequest<Guid>
{
    public Guid Id { get; init; }
}