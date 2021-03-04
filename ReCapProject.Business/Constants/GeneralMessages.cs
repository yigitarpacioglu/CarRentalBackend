using ReCapProject.Core.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ReCapProject.Business.Constants
{
    public static class GeneralMessages
    {
        public static string Maintenance = "System maintenance";
        public static string UserNotFound = "User couldn't found on the system";
        public static string PasswordError="Password is incorrect";
        public static string SuccesfulLogin="Succesfully login to system";
        public static string UserAlreadyExists="User is already registered in the system";
        public static string UserRegistered ="User registered successfully";
        public static string AccessTokenCreated="Access token has been created successfully";
        internal static string AuthorizationDenied="There is not such access identified for user";
    }
}
