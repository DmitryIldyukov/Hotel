using CommonLibrary.SeedWorks;
using RoomManager.Domain.Entities.Dicts;

namespace RoomManager.Domain.Entities;

/// <summary>
/// Номер в отеле
/// </summary>
public class Room : DbEntity
{
    /// <summary>
    /// Номер
    /// </summary>
    public int Number { get; set; }
    
    /// <summary>
    /// Id типа номера
    /// </summary>
    public Guid DictRoomTypeId { get; set; }
    
    /// <summary>
    /// Тип номера
    /// </summary>
    public DictRoomType DictRoomType { get; set; }
}