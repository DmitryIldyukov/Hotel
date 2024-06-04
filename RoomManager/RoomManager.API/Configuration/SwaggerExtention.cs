namespace Hotel.Configuration;

public static class SwaggerExtention
{
    public static void UseSwaggerUi(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}