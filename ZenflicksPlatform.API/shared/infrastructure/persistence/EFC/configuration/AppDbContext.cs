using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using zenflicks_backend.events.Domain.Model.Aggregates;
using zenflicks_backend.shared.infrastructure.persistence.EFC.configuration.extensions;
using zenflicks_backend.users.Domain.Model.Aggregates;

namespace zenflicks_backend.shared.infrastructure.persistence.EFC.configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u=>u.Name).IsRequired();
        builder.Entity<User>().Property(u=>u.LastName).IsRequired();
        builder.Entity<User>().Property(u => u.UserName).IsRequired();
        builder.Entity<User>().Property(u => u.BirthDate).IsRequired();
        builder.Entity<User>().Property(u => u.Phone).IsRequired();
        builder.Entity<User>().Property(u => u.Email).IsRequired();
        builder.Entity<User>().Property(u => u.Password).IsRequired();
        builder.Entity<User>().Property(u => u.Membership).IsRequired();

        builder.Entity<Event>().ToTable("Events");
        builder.Entity<Event>().HasKey(u => u.Id);
        builder.Entity<Event>().Property(u=>u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Event>().Property(u => u.contentId).IsRequired();
        builder.Entity<Event>().Property(u=>u.tittle).IsRequired();
        builder.Entity<Event>().Property(u=> u.address).IsRequired();
        builder.Entity<Event>().Property(u=>u.date).IsRequired();
        builder.Entity<Event>().Property(u=>u.creatorId).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
    }

    
}