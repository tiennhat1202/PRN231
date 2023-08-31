using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO.UserDTO
{
    public class UserChangePasswordDTO
    {
        public int UserId { get; set; }
        public string? Password { get; set; }
    }
}
