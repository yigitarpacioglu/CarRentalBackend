using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReCapProject.Business.Abstract;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAllCars()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }

        public void AddCarToSystem(Car car)
        {
            if (car.Descriptions.Length <= 10 || car.DailyPrice<0)
            {
                Console.WriteLine("1-Eklemek istediğiniz araç için açıklama kısmı 10 karakterden fazla olmalıdır,\n" +
                                  "2-Eklenecek olan aracın fiyatı 0'dan düşük olmamalıdır. ");
                return;
            }
            _carDal.Add(car);
            
            

        }

        public void UpdateCarInSystem(Car car)
        {
            _carDal.Update(car);
        }

        public void DeleteCarFromSystem(Car car)
        {
            _carDal.Delete(car);
        }
    }
}
