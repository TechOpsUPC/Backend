using zenflicks_backend.Infrastructure;
using zenflicks_backend.content.Domain.Repositories;
using zenflicks_backend.content.Infrastructure.Repositories;
using zenflicks_backend.content.Domain.Services;
using zenflicks_backend.content.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using zenflicks_backend.shared.infrastructure.interfaces.ASP.configuration;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

// Base de datos y otras configuraciones
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString != null)
    {
        options.UseMySQL(connectionString);
    }
});


// Registrar servicios
builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IContentCommandService, ContentCommandService>();
builder.Services.AddScoped<IContentQueryService, ContentQueryService>();

// Configuración de Swagger y demás middlewares
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Verificación de la base de datos
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configuración de la tubería de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();