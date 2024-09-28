﻿using System.ComponentModel.DataAnnotations;

namespace Car.Domain.DTO_s
{
    public class LoginDTO
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}