using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Constants
{
    public static class PaymentMessages
    {
        public static string PaymentAdded = "Payment has been added";
        public static string PaymentUpdated = "Payment has been updated";
        public static string PaymentDeleted = "Payment has been deleted";
        public static string PaymentListed = "Payment/Payments listed.";

        public static string InsufficientFund =
            "Rent order couldn't be performed because of insufficient fund in bank account";

        public static string PaymentSuccessful =
            "Payment performed succesfully. Car pickup address will be send over SMS to your mobile phone.";
    }
}
