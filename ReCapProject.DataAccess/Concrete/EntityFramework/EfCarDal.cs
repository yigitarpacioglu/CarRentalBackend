using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal: EfEntityRepositoryBase<Car,CarRentalDbContext>,ICarDal
    {
        //public override void Update(Car entity)
        //{
        //    using(CarRentalDbContext context = new CarRentalDbContext())
        //    {
        //        var carToUpdate = context.Cars.SingleOrDefault(p => p.CarId == entity.CarId);
        //        var properties = entity.GetType().GetProperties();
        //        foreach (var prop in properties)
        //        {
        //            if (prop.GetValue(entity) != null)
        //            {
        //                prop.SetValue(carToUpdate, prop.GetValue(entity));
        //            }
        //        }
        //        context.SaveChanges();
        //    }
        //}

        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join r in context.Colors on c.ColorId equals r.ColorId
                    select new CarDetailDto()
                    {
                        BrandName = b.BrandName, DailyPrice = c.DailyPrice, ColorName = r.ColorName, CarName = c.CarName
                    };
                return result.ToList();
            }
        }
    }
}
