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
             GetCarDetailsDto();
        }

        private static void GetCarDetailsDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
                foreach (var detail in result.Data)
                {
                    Console.WriteLine(" " + detail.BrandName + " " + detail.CarName + "\n Renk: " + detail.ColorName +
                                      "\n Kiralama bedeli: " + detail.DailyPrice + " (TL/Gün)\n");
                    Console.WriteLine("---------------------------------------\n");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void GetAllServiceForColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAllService();
            Console.WriteLine("\n------------------- GetAllService() Test-------------------\n");
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorId + " - " + color.ColorName);
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void DeleteServiceForColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ;
            Console.WriteLine("------------------- DeleteService(Color color) Test-------------------\n");
            var result = colorManager.DeleteService(new Color
            {
                ColorId = 6,
                ColorName = "Siyah"
            });
            Console.WriteLine(result.Message);
        }

        private static void UpdateServiceForColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("------------------- UpdateService(Color color) Test-------------------\n");
            var result = colorManager.UpdateService(new Color
            {
                ColorId = 6,
                ColorName = "Siyah"
            });
            Console.WriteLine(result.Message);
        }

        private static void AddServiceForColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("------------------- AddService(Color color) Test-------------------\n");
            var result = colorManager.AddService(new Color { ColorName = "Turuncu" });
            Console.WriteLine(result.Message);
        }

        private static void GetByIdForColor()
        {
            int ind = 2;
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetById(ind);
            Console.WriteLine("\n------------------- GetByIdService() Test-------------------\n");
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
                Console.WriteLine(result.Data.ColorId + " numaralı sıradaki araç rengi " + " - " +
                                  result.Data.ColorName + "\n");
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void GetAllServiceForBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("\n------------------- GetAllService() Test-------------------\n");
            var result = brandManager.GetAllService();
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandId + " - " + brand.BrandName);
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void DeleteServiceForBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("------------------- DeleteService(Brand brand) Test-------------------\n");
            var result = brandManager.DeleteService(new Brand
            {
                BrandId = 1002,
                BrandName = "Ford"
            });
            Console.WriteLine(result.Message);
        }

        private static void UpdateServiceForBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("------------------- UpdateService(Brand brand) Test-------------------\n");
            var result = brandManager.UpdateService(new Brand
            {
                BrandId = 1002,
                BrandName = "Ford"
            });
            Console.WriteLine(result.Message);
        }

        private static void AddServiceForBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("------------------- AddService(Brand brand) Test-------------------\n");
            var result = brandManager.AddService(new Brand { BrandName = "Skoda" });
            Console.WriteLine(result.Message);
        }

        private static void GetByIdServiceForBrand()
        {

            int ind = 2;
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetById(ind);
            Console.WriteLine("\n------------------- GetByIdService() Test-------------------\n");
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
                Console.WriteLine(result.Data.BrandId+ " numaralı sıradaki araç markası " + " - " +
                                                      brandManager.GetById(4).Data.BrandName + "\n");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetAllServiceForCar()
        {
            Console.WriteLine("\n------------------- GetAllService() Test-------------------\n");
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAllService();

            if (result.Success == true)
            {
                Console.WriteLine(result.Message + "\n");
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + " - \t Marka ID: " + car.BrandId + "\t\t\t    Model Adı: " +
                                      car.CarName
                                      + "\n\t Renk ID: " + car.ColorId + "\t\t\t    Açıklama: " + car.Descriptions
                                      + "\n\t Model Senesi: " + car.ModelYear
                                      + "\n\t Günlük Kiralama Bedeli: " + car.DailyPrice + " TL");
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void DeleteServiceForCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("------------------- DeleteService(Car car) Test-------------------\n");
            var result = carManager.DeleteService(new Car
            {
                CarId = 1003,
                ColorId = 3,
                BrandId = 1,
                CarName = "Megane Sedan",
                DailyPrice = 290,
                ModelYear = "2020",
                Descriptions = "Şanzıman:Otomatik, Yakıt:Dizel"
            });
            Console.WriteLine(result.Message);
        }

        private static void UpdateServiceForCar()
        {
            Console.WriteLine("------------------- UpdateService(Car car) Test-------------------\n");
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.UpdateService(new Car
            {
                CarId = 1003,
                ColorId = 3,
                BrandId = 1,
                CarName = "Megane Sedan",
                DailyPrice = 290,
                ModelYear = "2020",
                Descriptions = "Şanzıman:Otomatik, Yakıt:Dizel"
            });
            Console.WriteLine(result.Message);

        }

        private static void GetByIdTestForCar()
        {
            int ind = 2;
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetById(ind);
            Console.WriteLine("------------------- GetById(int id) Test-------------------\n");
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
                Console.WriteLine(result.Data.CarId + " - \t Marka ID: " + result.Data.BrandId + "\t\t\t    Model Adı: " +
                                  result.Data.CarName
                                  + "\n\t Renk ID: " + result.Data.ColorId + "\t\t\t    Açıklama: " + result.Data.Descriptions
                                  + "\n\t Model Senesi: " + result.Data.ModelYear
                                  + "\n\t Günlük Kiralama Bedeli: " + result.Data.DailyPrice + " TL");
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void AddServiceTestForCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("------------------- AddService(Car car) Test-------------------\n");
            var result = carManager.AddService(new Car
            {
                ColorId = 1,
                BrandId = 3,
                CarName = "Jetta",
                DailyPrice = 300,
                ModelYear = "2020",
                Descriptions = "Şanzıman:Otomatik, Yakıt:Dizel"
            });
            Console.WriteLine(result.Message);
        }

    }
}
