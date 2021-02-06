using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAllCars();
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        void AddCarToSystem(Car car);
        void UpdateCarInSystem(Car car);
        void DeleteCarFromSystem(Car car);
    }
}
