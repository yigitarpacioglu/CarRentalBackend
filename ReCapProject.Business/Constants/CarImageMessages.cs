using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Constants
{
    public static class CarImageMessages
    {
        public static string CarImageAdded = "Car image has been added";
        public static string CarImageUpdated = "Car image has been updated";
        public static string CarImageDeleted = "Car image been deleted";
        public static string CarImageListed = "Image/images listed";
        public static string CarImageLimitExceeded="Total image number for each car must be at most 5";
        public static string ImageFileNotExists="There is no such file in path";
        public static string MissmatchingFileExtension="Extension type must be .jpeg or .png";
    }
}
