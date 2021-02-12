using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ReCapProject.Business.Concrete;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.DataAccess.Concrete.EntityFramework;
using ReCapProject.DataAccess.Concrete.InMemory;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {

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

            // CRUD Tests for User Object //

            // AddServiceForUser();
            // UpdateServiceForUser();
            // DeleteServiceForUser();
            // GetAllServiceForUser();
            // GetByIdForUser();

            // CRUD Tests for Customer Object //
            // AddServiceForCustomer();
            // UpdateServiceForCustomer();
            // DeleteServiceForCustomer();
            // GetAllServiceForCustomer();
            // GetByIdForCustomer();

            // CRUD Tests for Rental Object //
            // AddServiceForRental();
            // UpdateServiceForRental();
            // DeleteServiceForRental();
            // GetAllServiceForRental();
            // GetByIdForRental();

            // DTO //
            // GetCarDetailsDto();


            User user = new User // Creating new account
            {
                FirstName = "Sabri",
                LastName = "Arpacıoğlu",
                Email = "sabriarpacioglu@gmail.com",
                Password = "456789"
            };
            
            AddServiceForUser(user); // Signing up to system as user

            CarManager carManager = new CarManager(new EfCarDal());
            

            var getDetailsResult = carManager.GetCarDetailsService(); // Listing Car Details
            if (getDetailsResult.Success == true)
            {
                Console.WriteLine(carManager.GetCarDetailsService().Message);
                foreach (var detail in getDetailsResult.Data)
                {
                    Console.WriteLine(" " + detail.BrandName + " " + detail.Description + "\n Color: " +
                                      detail.ColorName +
                                      "\n Daily Price: " + detail.DailyPrice + " (TL/Day)\n");
                    Console.WriteLine("---------------------------------------\n\n\n\n");
                }
            }
            else
            {
                Console.WriteLine(getDetailsResult.Message);
            }

            Car selectedCar = new Car // Car selected
            {
                CarId = 29
            };

            var selectedCarResult = carManager.GetCarDetailsByIdService(selectedCar.CarId);   // Details have been revealed
            
            var data = selectedCarResult.Data;

            if (selectedCarResult.Success == true)
            {
                Console.WriteLine(selectedCarResult.Message);
                
                    Console.WriteLine("\t\t Selected Car: " + data.BrandName + " " + data.Description +
                                      "\n\t\t Color: " + data.ColorName +
                                      "\n\t\t Daily Price: " + data.DailyPrice + " (TL/Day)\n");
                    Console.WriteLine("---------------------------------------\n");                
            }
            else
            {
                Console.WriteLine(selectedCarResult.Message);
            }

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var customerAddResult = customerManager.AddService(new Customer          //Decided to rent a car
            {
                UserId = 52,
                CompanyName = "Edremit ASM"
            });
            
            Console.WriteLine(customerAddResult.Message);

            RentalManager rentalManager = new RentalManager(new EfRentalDal()); // Car has been rent

            
            var rent1Result = rentalManager.AddService(new Rental
            {
                CarId = selectedCar.CarId,
                CustomerId = 22,
                RentDate = DateTime.Now,
            });
            Console.WriteLine("\n\n" + rent1Result.Message);

            rentalManager.UpdateService(new Rental
            {
                CarId = 15,
                CustomerId = 21,
                RentDate = DateTime.Now.AddDays(5),
            });

            string returnDate;
            var res = rentalManager.GetRentalDetails();
            foreach (var rental in res.Data)
            {
                returnDate = (rental.ReturnDate != null) ? (rental.ReturnDate.ToString()) : ("Araç teslim edilmemiştir");
                Console.WriteLine("\n Name          : " + rental.CustomerName+"\n Rented Vehicle: "+rental.Car
                                  +"\n Rent Date: " + rental.RentDate+"  -  Return Date: "+rental.ReturnDate+"\t\t Daily Price: "
                                  +rental.DailyPrice+" (Tl/day)" );
            }

        }
    
        
        private static void GetByIdForRental()
        {
            int ind = 2;
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetById(ind);
            Console.WriteLine("\n------------------- GetByIdService() Test-------------------\n");
            string returnDate;
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
                returnDate = (result.Data.ReturnDate != null) ? (result.Data.ReturnDate.ToString()) : ("Araç teslim edilmemiştir");

                Console.WriteLine(result.Data.Id + " - Araba No: " + result.Data.CarId + " Müşteri No: " + result.Data.CustomerId +
                                  " Araç Teslim Alma Tarihi: " + result.Data.RentDate + "Araç İade Tarihi: " + returnDate);
                Console.WriteLine("\n");

            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
        private static void GetAllServiceForRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAllService();
            Console.WriteLine("\n------------------- GetAllService() Test-------------------\n");
            string returnDate;
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
                foreach (var rental in result.Data)
                {
                    returnDate = (rental.ReturnDate != null) ? (rental.ReturnDate.ToString()) : ("\n Araç teslim edilmemiştir");

                    Console.WriteLine(rental.Id + " - Araba No: " + rental.CarId + " Müşteri No: " + rental.CustomerId +
                                      " Araç Teslim Alma Tarihi: " + rental.RentDate + "Araç İade Tarihi: " + returnDate);
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
        private static void DeleteServiceForRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("------------------- DeleteService(Rental rental) Test-------------------\n");
            var result = rentalManager.DeleteService(new Rental()
            {
                Id = 2,
                CarId = 3,
                CustomerId = 2,
                RentDate = DateTime.Today
            });
            Console.WriteLine(result.Message);
        }
        private static void UpdateServiceForRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("------------------- UpdateService(Rental rental) Test-------------------\n");
            var result = rentalManager.UpdateService(new Rental()
            {
                Id = 1,
                CarId = 3,
                CustomerId = 2,
                RentDate = DateTime.Today
            });
            Console.WriteLine(result.Message);
        }

        private static void AddServiceForRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("------------------- AddService(Customer customer) Test-------------------\n");
            var result = rentalManager.AddService(new Rental()
            {
                CarId = 2,
                CustomerId = 2,
                RentDate = DateTime.Today,
            });
            Console.WriteLine(result.Message);
        }
        private static void GetByIdForCustomer()
        {
            int ind = 2;
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetById(ind);
            Console.WriteLine("\n------------------- GetByIdService() Test-------------------\n");
            if (result.Success == true)
            {
                Console.WriteLine(result.Data.Id + " - " + result.Data.UserId + " " + result.Data.CompanyName);
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
        private static void GetAllServiceForCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAllService();
            Console.WriteLine("\n------------------- GetAllService() Test-------------------\n");
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.Id + " - User Id: " + customer.UserId + " Şirket İsmi: " + customer.CompanyName);
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
        private static void DeleteServiceForCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine("------------------- DeleteService(Customer customer) Test-------------------\n");
            var result = customerManager.DeleteService(new Customer
            {
                Id = 1,
                UserId = 2,
                CompanyName = "Marmara Üniversitesi"
            });
            Console.WriteLine(result.Message);
        }
        private static void UpdateServiceForCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine("------------------- UpdateService(Customer customer) Test-------------------\n");
            var result = customerManager.UpdateService(new Customer
            {
                Id = 1,
                UserId = 2,
                CompanyName = "Marmara Üniversitesi"
            });
            Console.WriteLine(result.Message);
        }

        private static void AddServiceForCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine("------------------- AddService(Customer customer) Test-------------------\n");
            var result = customerManager.AddService(new Customer
            {
                UserId = 2,
                CompanyName = "Yıldız Teknik Üniversitesi"

            });
            Console.WriteLine(result.Message);
        }
      
        private static void GetByIdForUser()
        {
            int ind = 2;
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetById(ind);
            Console.WriteLine("\n------------------- GetByIdService() Test-------------------\n");
            if (result.Success == true)
            {
                Console.WriteLine(result.Data.Id + " - " + result.Data.FirstName + " " + result.Data.FirstName + "\ne-mail: " + result.Data.Email + "\nşifre: " + result.Data.Password);
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
        private static void GetAllServiceForUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAllService();
            Console.WriteLine("\n------------------- GetAllService() Test-------------------\n");
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.Id + " - " + user.FirstName + " " +user.LastName+"\ne-mail: "+user.Email+"\nşifre: "+user.Password );
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
        private static void DeleteServiceForUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            Console.WriteLine("------------------- UpdateService(User user) Test-------------------\n");
            var result = userManager.DeleteService(new User
            {
                Id = 1,
                FirstName = "Yiğit",
                LastName = "Arpacı",
                Email = "yigit.arpacioglu@gmail.com",
                Password = "123456"
            });
            Console.WriteLine(result.Message);
        }
        private static void UpdateServiceForUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            Console.WriteLine("------------------- UpdateService(User user) Test-------------------\n");
            var result = userManager.UpdateService(new User
            {
                Id = 1,
                FirstName = "Yiğit",
                LastName = "Arpacı",
                Email = "yigit.arpacioglu@gmail.com",
                Password = "123456"
            });
            Console.WriteLine(result.Message);
        }

        private static void AddServiceForUser(User user)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            Console.WriteLine("------------------- AddService(User user) Test-------------------\n");
            var result = userManager.AddService(new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            });
            Console.WriteLine(result.Message);
        }

        private static void GetCarDetailsDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetailsService();
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
                foreach (var detail in result.Data)
                {
                    Console.WriteLine(" " + detail.BrandName + " " + detail.Description + "\n Renk: " + detail.ColorName +
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
                    Console.WriteLine(car.CarId + " - \t Marka ID: " + car.BrandId + "\t\t\t    Model Adı: " 
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
                DailyPrice = 290,
                ModelYear = 2020,
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
                DailyPrice = 290,
                ModelYear = 2020,
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
                Console.WriteLine(result.Data.CarId + " - \t Marka ID: " + result.Data.BrandId + "\t\t\t    Model Adı: "
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
                DailyPrice = 300,
                ModelYear = 2020,
                Descriptions = "Şanzıman:Otomatik, Yakıt:Dizel"
            });
            Console.WriteLine(result.Message);
        }

    }
}
