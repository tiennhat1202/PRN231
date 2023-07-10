using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO.UserDTO
{
    public class UserLoginResponse
    {
        public int? RoleId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
