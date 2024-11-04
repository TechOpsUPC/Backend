﻿using Microsoft.EntityFrameworkCore;
using zenflicks_backend.shared.infrastructure.persistence.EFC.configuration;
using zenflicks_backend.shared.infrastructure.persistence.EFC.repositories;
using zenflicks_backend.users.Domain.Model.Aggregates;
using zenflicks_backend.users.Domain.Repositories;

namespace zenflicks_backend.users.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    protected UserRepository(AppDbContext context) : base(context)
    {
    }

    public new async Task<User?> FindByIdAsync(int id)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> FindByUsernameAndPasswordAsync(string username, string password)
    {
       return await Context.Set<User>().FirstOrDefaultAsync(u => u.userName == username && u.password == password);
    }
}