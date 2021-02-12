using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entities;

namespace ReCapProject.Entities.Concrete
{
    public class Customer:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
