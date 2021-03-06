﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTutorial.ViewModel
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Message Is Too Small")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Message Is Too Long")]
        public string Message { get; set; }
    }
}