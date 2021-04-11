using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entities;

namespace ReCapProject.Entities.Concrete
{
    public class Payment:IEntity
    {
        public decimal Amount { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
