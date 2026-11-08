using DAL.Database;
using DAL.Models;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Implementations;

public class UserModelRepo(AppDbContext context) : IUserModelRepo
{

    private readonly AppDbContext _context = context;

    public async Task AddAsync(UserModel user)
    {
        await _context.Users.AddAsync(user);
    }

    public void Delete(UserModel user)
    {
        _context.Users.Remove(user);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<bool> ExistsByUsernameAsync(string username)
    {
        return await _context.Users.AnyAsync(u => u.Username == username);

    }

    public async Task<List<UserModel>> GetAllAsync()
    {
        return await _context.Users.AsNoTracking().ToListAsync();
    }

    public async Task<UserModel?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<UserModel?> GetByIdAsync(Guid userId)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<UserModel?> GetByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();

    }

    public void Update(UserModel user)
    {
        _context.Users.Update(user);
    }
}
