using MediatR;
using RoomManager.Domain.DTOs.DictRoomService;

namespace RoomManager.Application.Commands.DictRoomService;

public class GetAllRoomServiceCommand : IRequest<IEnumerable<DictRoomServiceGetDto>>
{
    
}