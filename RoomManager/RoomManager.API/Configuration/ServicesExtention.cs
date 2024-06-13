using RoomManager.Application.Services.Dicts.DictRoomService;

namespace Hotel.Configuration;

public static class ServicesExtention
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDictRoomServiceMapper, DictRoomServiceMapper>();
    }
}