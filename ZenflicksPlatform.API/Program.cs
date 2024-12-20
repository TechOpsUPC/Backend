using Microsoft.EntityFrameworkCore;
using zenflicks_backend.events.Application.Internal.CommandServices;
using zenflicks_backend.events.Application.Internal.QueryServices;
using zenflicks_backend.events.Domain.Repositories;
using zenflicks_backend.events.Domain.Services;
using zenflicks_backend.events.Infrastructure.Repositories;
using zenflicks_backend.shared.domain.repositories;
using zenflicks_backend.shared.infrastructure.interfaces.ASP.configuration;
using zenflicks_backend.shared.infrastructure.persistence.EFC.configuration;
using zenflicks_backend.shared.infrastructure.persistence.EFC.repositories;
using zenflicks_backend.users.Application.Internal.CommandServices;
using zenflicks_backend.users.Application.Internal.QueryServices;
using zenflicks_backend.users.Domain.Repositories;
using zenflicks_backend.users.Domain.Services;
using zenflicks_backend.users.Infrastructure.Repositories;
using zenflicks_backend.content.Domain.Repositories;
using zenflicks_backend.content.Infrastructure.Repositories;
using zenflicks_backend.content.Domain.Services;
using zenflicks_backend.content.Infrastructure.Services;
using zenflicks_backend.forums.Application.Internal.CommandServices;
using zenflicks_backend.forums.Application.Internal.QueryServices;
using zenflicks_backend.forums.Domain.Repositories;
using zenflicks_backend.forums.Domain.Services;
using zenflicks_backend.forums.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Bounded Context Injection Configuration (one for each bounded context)
//Example:
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
//Event Services
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventCommandService, EventCommandService>();
builder.Services.AddScoped<IEventQueryService, EventQueryService>();

builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IContentCommandService, ContentCommandService>();
builder.Services.AddScoped<IContentQueryService, ContentQueryService>();

builder.Services.AddScoped<IForumRepository, ForumRepository>();
builder.Services.AddScoped<IForumCommandService, ForumCommandService>();
builder.Services.AddScoped<IForumQueryService, ForumQueryService>();


var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();