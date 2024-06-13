using RoomManager.Domain.DTOs.DictRoomService;

namespace RoomManager.Application.Services.Dicts.DictRoomService;

public interface IDictRoomServiceMapper
{
    DictRoomServiceGetDto Map(Domain.Entities.Dicts.DictRoomService model);
}