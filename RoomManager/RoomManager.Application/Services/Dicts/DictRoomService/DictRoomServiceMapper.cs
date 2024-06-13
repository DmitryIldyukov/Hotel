using RoomManager.Domain.DTOs.DictRoomService;

namespace RoomManager.Application.Services.Dicts.DictRoomService;

public class DictRoomServiceMapper : IDictRoomServiceMapper
{
    public DictRoomServiceGetDto Map(Domain.Entities.Dicts.DictRoomService model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model), "Ошибка при маппинге: Услуга равна null.");

        return new DictRoomServiceGetDto(
            id: model.Id,
            name: model.Name,
            serialNumber: model.SerialNumber
        );
    }
}