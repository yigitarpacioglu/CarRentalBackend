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
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join r in context.Colors on c.ColorId equals r.ColorId
                    select new CarDetailDto()
                    {
                        CarId = c.CarId,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        ColorName = r.ColorName,
                        Description = c.Descriptions
                    };
                return result.ToList();
            }
        }
        public CarDetailDto GetCarDetailsById(Expression<Func<CarDetailDto, bool>> filter)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join r in context.Colors on c.ColorId equals r.ColorId
                    select new CarDetailDto()
                    {
                        CarId = c.CarId,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        ColorName = r.ColorName,
                        Description = c.Descriptions
                    };
                return result.SingleOrDefault(filter);
            }
        }
    }
}
