namespace RoomManager.Domain.Exceptions;

public class RecordNotFound : Exception
{
    public RecordNotFound(string message) : base(message) { }
}