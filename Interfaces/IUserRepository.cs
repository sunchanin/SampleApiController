using System;
using SampleApiController.Entities;

namespace SampleApiController.Interfaces;

public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllSync();
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser?> GetUserByIdAsync(int id);
    Task <AppUser?> GetUserByUsernameAsync(string username);
}
