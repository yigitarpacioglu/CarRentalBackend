using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entites;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Entities.DTOs
{
    public class BalanceUpdateDto:IDto
    {
        public CustomerDetailDto Customer { get; set; }
        public decimal Cash { get; set; }
    }
}
