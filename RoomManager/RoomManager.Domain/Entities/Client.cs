using CommonLibrary.SeedWorks;

namespace RoomManager.Domain.Entities;

public class Client : DbEntity
{
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; set; }
    
    /// <summary>
    /// Отчество (если есть)
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// ФИО
    /// </summary>
    public string FIO => $"{FirstName} {Surname}" + Patronymic == null ? string.Empty : $" {Patronymic}";
}