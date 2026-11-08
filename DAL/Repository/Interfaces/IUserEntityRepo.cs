using System;
using DAL.Models;

namespace DAL.Repository.Interfaces;

public interface IUserModelRepo
{
    // create 
    Task AddAsync(UserModel user);
    // update
    void Update(UserModel user);
    // delete
    void Delete(UserModel user);
    // read
    Task<List<UserModel>> GetAllAsync();

    Task<UserModel?> GetByIdAsync(Guid userId);
    Task<UserModel?> GetByUsernameAsync(string username);
    Task<UserModel?> GetByEmailAsync(string email);


    Task<bool> ExistsByEmailAsync(string email);

    Task<bool> ExistsByUsernameAsync(string username);

    Task SaveChangesAsync();

}
