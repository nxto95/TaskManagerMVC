using System;
using BLL.Dtos;

namespace BLL.Services.Interfaces;

public interface IUserService
{
    Task<UserResponseDto?> GetByIdAsync(Guid userId);

    Task<UserResponseDto?> RegisterAsync(UserRegisterDto dto);

    Task<UserResponseDto?> LoginAsync(UserLoginDto dto);
}
