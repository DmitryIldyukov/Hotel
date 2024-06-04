using Microsoft.EntityFrameworkCore;
using RoomManager.Infrastructure.Data;

namespace Hotel.Configuration;

public static class DatabaseExtention
{
    public static void AddDatabase(this IServiceCollection service, string connectionString)
    {
        service.AddDbContext<RoomManagerDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
    }
}