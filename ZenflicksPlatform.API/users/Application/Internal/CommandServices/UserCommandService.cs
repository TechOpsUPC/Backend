using Microsoft.AspNetCore.Identity;
using zenflicks_backend.shared.domain.repositories;
using zenflicks_backend.users.Domain.Model.Aggregates;
using zenflicks_backend.users.Domain.Model.Commands;
using zenflicks_backend.users.Domain.Repositories;
using zenflicks_backend.users.Domain.Services;

namespace zenflicks_backend.users.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    : IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
       var user = await userRepository.FindByUsernameAndPasswordAsync(command.userName, command.password);
       if(user != null) throw new Exception("User with this username not found");
         user = new User(command);
         try
         {
                await userRepository.AddAsync(user);
                await unitOfWork.CompleteAsync();
         }
         catch (Exception e)
         {
             return null;
         }
         return user;
    }
}