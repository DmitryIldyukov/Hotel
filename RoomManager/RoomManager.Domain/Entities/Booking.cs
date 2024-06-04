namespace RoomManager.Domain.Entities;

public class Booking
{
    /// <summary>
    /// Id клиента
    /// </summary>
    public Guid ClientId { get; set; }
    
    /// <summary>
    /// Клиент
    /// </summary>
    public Client Client { get; set; }

    /// <summary>
    /// Id номера
    /// </summary>
    public Guid RoomId { get; set; }
    
    /// <summary>
    /// Номер
    /// </summary>
    public Room Room { get; set; }

    /// <summary>
    /// Дата заселения
    /// </summary>
    public DateTime CheckInDate { get; set; }
    
    /// <summary>
    /// Дата выезда
    /// </summary>
    public DateTime CheckOutDate { get; set; }

    /// <summary>
    /// Дата бронирования
    /// </summary>
    public DateTime BookingDate { get; set; }
}