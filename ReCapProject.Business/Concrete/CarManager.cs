using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReCapProject.Business.Abstract;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public List<Car> GetAllService()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(p => p.CarId == id);
        }

        public void AddService(Car entity)
        {
            
            if (entity.Descriptions.Length <= 10 || entity.DailyPrice < 0)
            {
                Console.WriteLine("1-Eklemek istediğiniz araç için açıklama kısmı 10 karakterden fazla olmalıdır,\n" +
                                  "2-Eklenecek olan aracın fiyatı 0'dan düşük olmamalıdır. ");
                return;
            }
            _carDal.Add(entity);
            Console.WriteLine("Araba kaydı başarıyla oluşturuldu");
        }

        public void UpdateService(Car entity)
        {
            _carDal.Update(entity);
            Console.WriteLine("Araba kaydı başarıyla güncellendi");
        }

        public void DeleteService(Car entity)
        {
            _carDal.Delete(entity);
            Console.WriteLine("Araba kaydı başarıyla silindi");
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
