namespace RoomManager.Domain.Exceptions;

public class RecordAlreadyExist : Exception
{
    public RecordAlreadyExist(string message) : base(message) { }
}