using System;
using ReCapProject.Business.Concrete;
using ReCapProject.DataAccess.Concrete.EntityFramework;
using ReCapProject.DataAccess.Concrete.InMemory;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            // BrandManager brandManager = new BrandManager(new EfBrandDal());
            // ColorManager colorManager = new ColorManager(new EfColorDal());
            
            // CRUD Tests for Car Object //

            // AddServiceTestForCar();
            // GetByIdTestForCar();
            // UpdateServiceForCar();
            // DeleteServiceForCar();
            // GetAllServiceForCar();

            // CRUD Tests for Brand Object //

            // GetByIdServiceForBrand();
            // AddServiceForBrand();
            // UpdateServiceForBrand();
            // DeleteServiceForBrand();
            // GetAllServiceForBrand();

            // CRUD Tests for Color Object //
            // GetByIdForColor();
            // AddServiceForColor();
            // UpdateServiceForColor();
            // DeleteServiceForColor();
            // GetAllServiceForColor();

            // DTO //
            // GetCarDetailsDto();
        }

        private static void GetCarDetailsDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var detail in carManager.GetCarDetails())
            {
                Console.WriteLine(" " + detail.BrandName + " " + detail.CarName + "\n Renk: " + detail.ColorName +
                                  "\n Kiralama bedeli: " + detail.DailyPrice + " (TL/Gün)\n");
                Console.WriteLine("---------------------------------------\n");
            }
        }

        private static void GetAllServiceForColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("\n------------------- GetAllService() Test-------------------\n");
            foreach (var color in colorManager.GetAllService())
            {
                Console.WriteLine(color.ColorId + " - " + color.ColorName);
                Console.WriteLine("\n");
            }
        }

        private static void DeleteServiceForColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal()); ;
            Console.WriteLine("------------------- DeleteService(Color color) Test-------------------\n");
            colorManager.DeleteService(new Color
            {
                ColorId = 6,
                ColorName = "Siyah"
            });
        }

        private static void UpdateServiceForColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("------------------- UpdateService(Color color) Test-------------------\n");
            colorManager.UpdateService(new Color
            {
                ColorId = 6,
                ColorName = "Siyah"
            });
        }

        private static void AddServiceForColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("------------------- AddService(Color color) Test-------------------\n");
            colorManager.AddService(new Color {ColorName = "Turuncu"});
        }

        private static void GetByIdForColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("\n------------------- GetByIdService() Test-------------------\n");
            Console.WriteLine("4 numaralı sıradaki araç rengi: " + colorManager.GetById(4).ColorId + " - " +
                              colorManager.GetById(4).ColorName + "\n");
            Console.WriteLine("2 numaralı sıradaki araç rengi: " + colorManager.GetById(2).ColorId + " - " +
                              colorManager.GetById(2).ColorName + "\n");
            Console.WriteLine("6 numaralı sıradaki araç rengi: " + colorManager.GetById(3).ColorId + " - " +
                              colorManager.GetById(3).ColorName + "\n");
        }

        private static void GetAllServiceForBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("\n------------------- GetAllService() Test-------------------\n");
            foreach (var brand in brandManager.GetAllService())
            {
                Console.WriteLine(brand.BrandId + " - " + brand.BrandName);
                Console.WriteLine("\n");
            }
        }

        private static void DeleteServiceForBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("------------------- DeleteService(Brand brand) Test-------------------\n");
            brandManager.DeleteService(new Brand
            {
                BrandId = 5,
                BrandName = "Ford"
            });
        }

        private static void UpdateServiceForBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("------------------- UpdateService(Brand brand) Test-------------------\n");
            brandManager.UpdateService(new Brand
            {
                BrandId = 5,
                BrandName = "Ford"
            });
        }

        private static void AddServiceForBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("------------------- AddService(Brand brand) Test-------------------\n");
            brandManager.AddService(new Brand {BrandName = "Skoda"});
        }

        private static void GetByIdServiceForBrand()
        {
            BrandManager brandManager=new BrandManager(new EfBrandDal());
            Console.WriteLine("\n------------------- GetByIdService() Test-------------------\n");
            Console.WriteLine("4 numaralı sıradaki araç markası: " + brandManager.GetById(4).BrandId + " - " +
                              brandManager.GetById(4).BrandName + "\n");
            Console.WriteLine("2 numaralı sıradaki araç markası: " + brandManager.GetById(2).BrandId + " - " +
                              brandManager.GetById(2).BrandName + "\n");
            Console.WriteLine("6 numaralı sıradaki araç markası: " + brandManager.GetById(3).BrandId + " - " +
                              brandManager.GetById(3).BrandName + "\n");
        }

        private static void GetAllServiceForCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("\n------------------- GetAllService() Test-------------------\n");
            foreach (var car in carManager.GetAllService())
            {
                Console.WriteLine(car.CarId + " - \t Marka ID: " + car.BrandId + "\t\t\t    Model Adı: " + car.CarName
                                  + "\n\t Renk ID: " + car.ColorId + "\t\t\t    Açıklama: " + car.Descriptions
                                  + "\n\t Model Senesi: " + car.ModelYear
                                  + "\n\t Günlük Kiralama Bedeli: " + car.DailyPrice + " TL");
                Console.WriteLine("\n");
            }
        }

        private static void DeleteServiceForCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("------------------- DeleteService(Car car) Test-------------------\n");
            carManager.DeleteService(new Car
            {
                CarId = 8,
                ColorId = 3,
                BrandId = 1,
                CarName = "Megane Sedan",
                DailyPrice = 290,
                ModelYear = "2020",
                Descriptions = "Şanzıman:Otomatik, Yakıt:Dizel"
            });
        }

        private static void UpdateServiceForCar()
        {
            Console.WriteLine("------------------- UpdateService(Car car) Test-------------------\n");
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.UpdateService(new Car
            {
                CarId = 8,
                ColorId = 3,
                BrandId = 1,
                CarName = "Megane Sedan",
                DailyPrice = 290,
                ModelYear = "2020",
                Descriptions = "Şanzıman:Otomatik, Yakıt:Dizel"
            });
        }

        private static void GetByIdTestForCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("------------------- GetById(int id) Test-------------------\n");
            Console.WriteLine("4 numaralı sıradaki araç: " + carManager.GetById(4).CarId + " - " +
                              carManager.GetById(4).CarName + "\n");
            Console.WriteLine("2 numaralı sıradaki araç: " + carManager.GetById(2).CarId + " - " +
                              carManager.GetById(2).CarName + "\n");
            Console.WriteLine("6 numaralı sıradaki araç: " + carManager.GetById(6).CarId + " - " +
                              carManager.GetById(6).CarName + "\n");
        }

        private static void AddServiceTestForCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("------------------- AddService(Car car) Test-------------------\n");
            carManager.AddService(new Car
            {
                ColorId = 1, BrandId = 1, CarName = "Megane Sedan", DailyPrice = 290,
                ModelYear = "2019", Descriptions = "Şanzıman:Otomatik, Yakıt:Dizel"
            });
        }
    }
}
