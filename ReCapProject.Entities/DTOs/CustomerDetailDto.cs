using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entites;

namespace ReCapProject.Entities.DTOs
{
    public class CustomerDetailDto:IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public decimal Balance { get; set; }
    }
}
