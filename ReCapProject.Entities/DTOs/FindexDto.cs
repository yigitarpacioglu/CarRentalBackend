using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entites;

namespace ReCapProject.Entities.DTOs
{
    public class FindexDto:IDto
    {
        public int userId { get; set; }
        public int carId { get; set; }
    }
}
