using RoomManager.Application.Handlers;

namespace Hotel.Configuration;

public static class MediatorExtention
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(RoomServiceCommandHandler).Assembly);
        });
    }
}