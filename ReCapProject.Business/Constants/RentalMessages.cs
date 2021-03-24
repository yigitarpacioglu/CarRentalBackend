using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Constants
{
    public static class RentalMessages
    {
        public static string RentalAdded = "Car has has been rented succesfully";
        public static string RentalUpdated = "Rental record has been updated";
        public static string RentalDeleted = "Rental record has been removed from database";
        public static string RentalListed = "Rental Records";
        public static string RentalReturnDateError = "Rent operation couldn't be done because of that vehicle is still on another customer";
    }
}
