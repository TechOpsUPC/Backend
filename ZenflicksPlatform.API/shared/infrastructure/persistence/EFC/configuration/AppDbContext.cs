﻿using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using zenflicks_backend.events.Domain.Model.Aggregates;
using zenflicks_backend.shared.infrastructure.persistence.EFC.configuration.extensions;
using zenflicks_backend.users.Domain.Model.Aggregates;
using zenflicks_backend.content.Domain.Model;
using zenflicks_backend.forums.Domain.Model.Aggregates;

namespace zenflicks_backend.shared.infrastructure.persistence.EFC.configuration;

public class AppDbContext : DbContext
{
    public DbSet<Content> Contents { get; set; }
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


        builder.Entity<Content>().ToTable("Content");
        builder.Entity<Content>().HasKey(u => u.Id);
        builder.Entity<Content>().Property(u=> u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Content>().Property(u => u.Title).IsRequired();
        builder.Entity<Content>().Property(u => u.Description).IsRequired();
        builder.Entity<Content>().Property(u => u.Director).IsRequired();
        builder.Entity<Content>().Property(u => u.Duration).IsRequired();
        builder.Entity<Content>().Property(u => u.Genre).IsRequired();

        builder.Entity<Event>().ToTable("Events");
        builder.Entity<Event>().HasKey(u => u.Id);
        builder.Entity<Event>().Property(u=>u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Event>().Property(u => u.contentId).IsRequired();
        builder.Entity<Event>().Property(u=>u.tittle).IsRequired();
        builder.Entity<Event>().Property(u=> u.address).IsRequired();
        builder.Entity<Event>().Property(u=>u.date).IsRequired();
        builder.Entity<Event>().Property(u=>u.creatorId).IsRequired();

        builder.Entity<Forum>().ToTable("Forums");
        builder.Entity<Forum>().HasKey(f => f.Id);
        builder.Entity<Forum>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Forum>().Property(f => f.Title).IsRequired();
        builder.Entity<Forum>().Property(f => f.CommentBy).IsRequired();
        builder.Entity<Forum>().Property(f => f.Comment).IsRequired();
        builder.Entity<Forum>().Property(f => f.Image).IsRequired();
        builder.Entity<Forum>().Property(f => f.Score).IsRequired();
        

        builder.UseSnakeCaseNamingConvention();
    }

    
}