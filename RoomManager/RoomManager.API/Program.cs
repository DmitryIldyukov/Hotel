using Hotel.Configuration;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddMediator();
    
    builder.Services.AddControllers();
    
    var connectionString = builder.Configuration.GetConnectionString("PostreSQLConnection");
    builder.Services.AddDatabase(connectionString);
    
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    app.MapControllers();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwaggerUi();
    }

    app.UseAuthentication();
    app.UseAuthorization();
    
    app.UseHttpsRedirection();

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message, "Сервер неожиданно завершил работу.");
}
finally
{
    Console.WriteLine("Сервер отключается...");
}
