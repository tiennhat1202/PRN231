﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.RoleDTO
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public string RoleDesc { get; set; }
    }
}
