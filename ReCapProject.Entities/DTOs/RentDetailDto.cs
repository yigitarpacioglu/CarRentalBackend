using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entites;

namespace ReCapProject.Entities.DTOs
{
    public class RentDetailDto:IDto
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
