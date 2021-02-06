using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car() {CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 118.750, ModelYear = 2013,
                    Descriptions = "DEĞİŞENSİZ TRAMERSİZ 2 PARÇA BOYALI RENAULT CLIO"},
                new Car() {CarId = 2, BrandId = 1, ColorId = 1, DailyPrice = 184.000, ModelYear = 2019,
                    Descriptions = "HATASIZ BOYASIZ TESLA EKRANLI ÇELİK JANTLI RENAULT MEGANE"},
                new Car() {CarId = 3, BrandId = 1, ColorId = 2, DailyPrice =42.000, ModelYear = 1992,
                    Descriptions = "OTOMATİK KLİMALI CLIO"},
                new Car() {CarId = 4, BrandId = 2, ColorId = 3, DailyPrice = 98.500, ModelYear = 2009,
                    Descriptions = "DOĞAN OTOMOTİVDEN SUNROOF DEĞİŞENSİZ HASAR KAYITSIZ CITROEN C5"},
                new Car() {CarId = 5, BrandId = 2, ColorId = 4, DailyPrice = 208.000, ModelYear = 2020,
                    Descriptions = "Sahibinden tertemiz c3"}

            };
        }
        public List<Car> GetByBrandId(int brandId) => _cars.Where(p => p.BrandId == brandId).ToList();
        

        public Car Get(int id)
        {
            return _cars.SingleOrDefault(p=>p.CarId==id);
        }


        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            if (_cars.SingleOrDefault(p => p.CarId == car.CarId) == null)
            {
                _cars.Add(car);
            }
            else
            {
                throw new WarningException("\nSistemde bu ID ile araç tanımlanmıştır, lütfen başka bir ID seçiniz.\n");
            }
        }
        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            var properties = car.GetType().GetProperties();
            foreach (var prop in properties)
            {
                if (prop.GetValue(car) != null) 
                { 
                    prop.SetValue(carToUpdate, prop.GetValue(car)); 
                }
            }
        }

        
    }
}
