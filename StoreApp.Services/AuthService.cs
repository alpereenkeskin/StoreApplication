using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StoreApp.Entites.Dtos;
using StoreApp.Services.Concrete;

namespace StoreApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AuthService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<IdentityRole> Roles =>
            _roleManager.Roles;

        public async Task<IdentityResult> CreateUserAsync(UserCreationDto userDto)
        {
            var user = _mapper.Map<IdentityUser>(userDto);
            var userResult = await _userManager.CreateAsync(user, userDto.Password);
            if (!userResult.Succeeded)
            {
                foreach (var item in userResult.Errors)
                {
                    return userResult;
                }

            }
            if (userDto.Roles?.Count > 0)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                if (!roleResult.Succeeded)
                {
                    return userResult;
                }
            }
            return userResult;
        }

        public async Task<IdentityResult> DeleteUser(string username)
        {
            var user = await GetOneUser(username);
            return await _userManager.DeleteAsync(user);
        }

        public IEnumerable<IdentityUser> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public async Task<IdentityUser> GetOneUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user is not null)
            {
                return user;
            }
            throw new Exception("user could not be found");
        }

        public async Task<UserUpdateDto> GetOneUserForUpdate(string username)
        {
            var user = await GetOneUser(username);
            var userDto = _mapper.Map<UserUpdateDto>(user);
            userDto.Roles = new HashSet<string>(Roles.Select(x => x.Name).ToList());
            userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));
            return userDto;
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var user = await _userManager.FindByNameAsync(resetPasswordDto.Username);
            await _userManager.RemovePasswordAsync(user);
            var newPasswordResult = await _userManager.AddPasswordAsync(user, resetPasswordDto.Password);
            return newPasswordResult;
        }

        public async Task UpdateUser(UserUpdateDto updateDto)
        {
            var user = await GetOneUser(updateDto.UserName);
            user.Email = updateDto.Email;
            user.PhoneNumber = updateDto.PhoneNumber;
            //var useridentty = _mapper.Map<IdentityUser>(updateDto);
            var updateResult = await _userManager.UpdateAsync(user);
            if (updateDto.Roles.Count > 0)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                var roleAddResult = await _userManager.AddToRolesAsync(user, updateDto.Roles);
            }

        }
    }
}