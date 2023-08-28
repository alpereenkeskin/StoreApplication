using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using StoreApp.Entites.Dtos;
using StoreApp.Services.Concrete;

namespace StoreApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class RoleController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public RoleController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            return View(_serviceManager.AuthService.Roles);
        }

        public IActionResult GetUsers()
        {
            var userlist = _serviceManager.AuthService.GetAllUsers();
            return View(_serviceManager.AuthService.GetAllUsers());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        public IActionResult Create()
        {
            return View(new UserCreationDto()
            {
                Roles = new HashSet<string>(_serviceManager
              .AuthService
              .Roles
              .Select(x => x.Name)
              .ToList()
              )
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserCreationDto userCreationDto)
        {
            var result = await _serviceManager.AuthService.CreateUserAsync(userCreationDto);
            if (result.Succeeded)
            {
                return RedirectToAction("GetUsers", "Role");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(new UserCreationDto()
            {
                Roles = new HashSet<string>(_serviceManager
              .AuthService
              .Roles
              .Select(x => x.Name)
              .ToList()
              )
            });
        }
        public async Task<IActionResult> Update(string username)
        {
            var user = await _serviceManager.AuthService.GetOneUserForUpdate(username);

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] UserUpdateDto userUpdateDto)
        {
            var user = await _serviceManager.AuthService.GetOneUserForUpdate(userUpdateDto.UserName);
            if (ModelState.IsValid)
            {
                await _serviceManager.AuthService.UpdateUser(userUpdateDto);
                return RedirectToAction("GetUsers", "Role");
            }

            return View(userUpdateDto);
        }
        public IActionResult ResetPassword(string username)
        {
            return View(new ResetPasswordDto
            {
                Username = username
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _serviceManager.AuthService.GetOneUser(resetPasswordDto.Username);
                var resetPasswordResult = await _serviceManager
                    .AuthService
                    .ResetPassword(resetPasswordDto);
                if (resetPasswordResult.Succeeded)
                {
                    return RedirectToAction("GetUsers", "Role");
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser([FromForm] UserDto userDto)
        {
            var result = await _serviceManager
            .AuthService
            .DeleteUser(userDto.UserName);
            if (result.Succeeded)
            {
                return RedirectToAction("GetUsers", "Role");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }



    }
}