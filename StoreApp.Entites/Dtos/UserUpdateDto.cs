using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Entites.Dtos
{
    public record UserUpdateDto : UserDto
    {
        
        public HashSet<string> UserRoles { get; set; } = new HashSet<string>();

    }
}