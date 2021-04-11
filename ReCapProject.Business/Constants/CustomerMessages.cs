using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Constants
{
    public static class CustomerMessages
    {
        public static string CustomerAdded = "Customer has been added";
        public static string CustomerUpdated = "Customer has been updated";
        public static string CustomerDeleted = "Customer has been deleted";
        public static string CustomersListed = "Customers/Customer listed";
        public static string RedirectingToPayment = "You are being redirecting to Payment Page ";

        public static string AmountUnderMinLimit =
            "Amount of balance you would like to placed is under limit. Please place higher balance.";
        public static string SuccessfulBalanceUpdate = " Cash has been transferred to the account successfully";
    }
}
