using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entites;

namespace ReCapProject.Entities.DTOs
{
    public class UserForLoginDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
