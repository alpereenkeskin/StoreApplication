using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Entites.Dtos
{
    public record UserCreationDto : UserDto
    {
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public String? Password { get; set; }

    }
}