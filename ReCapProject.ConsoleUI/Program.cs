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
            CarManager carManager = new CarManager(new EfCarDal());
            
            Console.WriteLine("Sistemdeki mevcut araçlar:");
            Console.WriteLine("--------------------------");
            

            foreach (var car in carManager.GetAllCars())
            {
               Console.WriteLine(car.CarId+" - "+car.Descriptions+"\n"
                                 +"\t\tMarka Kodu: "+car.BrandId+"\t\t Renk Kodu:"+car.ColorId + "\n"
                                 +"\t\tÜretim Yılı: "+car.ModelYear+"\t Güncel Fiyatı: "+car.DailyPrice.ToString("#.000")+" TL\n");
            }
            Console.WriteLine("--------------------------");

            Console.WriteLine("GetCarsByBrandId Servisi:");
            Console.WriteLine("--------------------------");


            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.CarId + " - " + car.Descriptions + "\n"
                                  + "\t\tMarka Kodu: " + car.BrandId + "\t\t Renk Kodu:" + car.ColorId + "\n"
                                  + "\t\tÜretim Yılı: " + car.ModelYear + "\t Güncel Fiyatı: " + car.DailyPrice.ToString("#.000") + " TL\n");
            }
            Console.WriteLine("--------------------------");

            Console.WriteLine("GetCarsByColor Servisi:");
            Console.WriteLine("--------------------------");


            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.CarId + " - " + car.Descriptions + "\n"
                                  + "\t\tMarka Kodu: " + car.BrandId + "\t\t Renk Kodu:" + car.ColorId + "\n"
                                  + "\t\tÜretim Yılı: " + car.ModelYear + "\t Güncel Fiyatı: " + car.DailyPrice.ToString("#.000") + " TL\n");
            }
            Console.WriteLine("--------------------------");




        }
    }
}
