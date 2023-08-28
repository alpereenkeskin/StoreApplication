using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StoreApp.Entites.Dtos;

namespace StoreApp.Services.Concrete
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IEnumerable<IdentityUser> GetAllUsers();
        Task<IdentityResult> CreateUserAsync(UserCreationDto userDto);
        Task<IdentityUser> GetOneUser(string username);
        Task<UserUpdateDto> GetOneUserForUpdate(string username);
        Task UpdateUser(UserUpdateDto updateDto);
        Task<IdentityResult> ResetPassword(ResetPasswordDto resetPasswordDto);
        Task<IdentityResult> DeleteUser(string username);

    }
}