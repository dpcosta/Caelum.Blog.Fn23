﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class LoginViewModel
    {
        [Required]
        public string LoginName { get; set; }
        public string Password { get; set; }
    }
}
