using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entites;

namespace ReCapProject.Entities.DTOs
{
    public class RentDetailDto:IDto
    {
        public string Customer { get; set; }
        public string Car { get; set; }
        public decimal DailyPrice  { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
