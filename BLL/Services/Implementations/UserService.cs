using BLL.Dtos;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services.Implementations;

public class UserService(IUserModelRepo userModelRepo, IPasswordHasher<UserModel> passwordHasher) : IUserService
{
    private readonly IUserModelRepo _userModelRepo = userModelRepo;
    private readonly IPasswordHasher<UserModel> _passwordHasher = passwordHasher;


    public async Task<UserResponseDto?> GetByIdAsync(Guid userId)
    {
        UserModel? user = await _userModelRepo.GetByIdAsync(userId) ?? throw new Exception("user not found"); ;
        UserResponseDto userResponse = new()
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
        return userResponse;
    }

    public async Task<UserResponseDto?> LoginAsync(UserLoginDto dto)
    {
        var user = await _userModelRepo.GetByEmailAsync(dto.Email) ?? throw new Exception("Invalid credentials");
        if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password) == PasswordVerificationResult.Failed)
            throw new Exception("Invalid credentials");
        UserResponseDto userResponse = new()
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
        return userResponse;

    }

    public async Task<UserResponseDto?> RegisterAsync(UserRegisterDto dto)
    {

        if (await _userModelRepo.ExistsByEmailAsync(dto.Email))
            throw new Exception("email already exists");

        if (await _userModelRepo.ExistsByUsernameAsync(dto.Username))
            throw new Exception("username already exists");

        UserModel user = new()
        {
            Username = dto.Username,
            Email = dto.Email,
        };
        user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);
        await _userModelRepo.AddAsync(user);
        await _userModelRepo.SaveChangesAsync();
        UserResponseDto userResponse = new()
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
        return userResponse;

    }
}
