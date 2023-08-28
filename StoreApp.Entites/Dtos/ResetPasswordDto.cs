using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entites.Dtos
{
    public record ResetPasswordDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Parolalar uyuşmuyor.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
