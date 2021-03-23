using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entites;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Entities.DTOs
{
    public class RentOrderDto:IDto
    {
        public Rental Rental { get; set; }
        public Payment Payment { get; set; }
    }
}
