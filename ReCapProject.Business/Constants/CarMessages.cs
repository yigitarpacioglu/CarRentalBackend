using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Constants
{
    public static class CarMessages
    {
        public static string CarAdded = "Araç ilanı eklendi";
        public static string CarUpdated = "Araç ilanı güncellendi";
        public static string CarDeleted = "Araç ilanı silindi";
        public static string CarAddError = "Araç adı 2 karakterden fazla olmalı ve günlük kiralama bedeli için negatif değer girilmemelidir.";
        public static string CarsListed = "Araç/Araçlar listelendi.";
        public static string Maintenance = "Sistem bakımdadır.";
    }
}
