namespace RoomManager.Domain.Entities.Dicts;

public class DictRoomType
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Сокращенное описание
    /// </summary>
    public string? SDescription { get; set; }

    /// <summary>
    /// Картинки
    /// </summary>
    public ICollection<string>? Pictures { get; set; }
    
    /// <summary>
    /// Доступные сервисы
    /// </summary>
    public ICollection<DictRoomService>? DictRoomServices { get; set; }
}