using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entites;

namespace ReCapProject.Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImagePath { get; set; }
    }
}
