﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.UserDTO
{
    public class UserFormLoginDTO
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
