namespace RoomManager.Domain.DTOs.DictRoomService;

public class DictRoomServiceGetDto
{
    public DictRoomServiceGetDto(
        Guid id,
        string name,
        int? serialNumber = null
    )
    {
        Id = id;
        Name = name;
        SerialNumber = serialNumber;
    }
    
    public Guid Id { get; init; } 
    public string Name { get; init; }
    public int? SerialNumber { get; init; }
}