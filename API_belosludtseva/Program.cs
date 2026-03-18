var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Добавляем Swagger только ОДИН раз с двумя версиями
builder.Services.AddSwaggerGen(option => {
    // Версия v1
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Руководство для использования запросов",
        Description = "Полное руководство для использования GET запросов"
    });

    // Версия v2
    option.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v2",
        Title = "Руководство для использования запросов",
        Description = "Полное руководство для использования POST запросов"
    });

    // Добавляем XML комментарии (с проверкой существования файла)
    var xmlFile = "API_belosludtseva.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        option.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Настраиваем Swagger UI
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Запросы GET");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Запросы POST");
    c.RoutePrefix = "swagger"; // Это сделает swagger доступным по корневому пути
});

app.Run();