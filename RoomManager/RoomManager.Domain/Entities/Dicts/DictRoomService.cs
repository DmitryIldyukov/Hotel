using CommonLibrary.SeedWorks;

namespace RoomManager.Domain.Entities.Dicts;

/// <summary>
/// Услуги
/// </summary>
public class DictRoomService : DbEntity
{
    public DictRoomService(string name, int? serialNumber = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        SerialNumber = serialNumber;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public string Name { get; set; }
    public int? SerialNumber { get; set; }
}