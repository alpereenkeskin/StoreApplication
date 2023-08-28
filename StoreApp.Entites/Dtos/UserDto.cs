using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Entites.Dtos
{
    public record UserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Username is required!")]
        public string? UserName { get; set; }


        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required!")]
        public string? Email { get; set; }



        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number is required!")]
        public string? PhoneNumber { get; set; }

        public HashSet<string>? Roles { get; set; } = new HashSet<string>();
    }
}