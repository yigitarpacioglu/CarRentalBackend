using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,CarRentalDbContext>,IRentalDal
    {
        public List<RentDetailDto> GetRentalDetails()
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result = from r in context.Rentals
                    join c in context.Cars on r.CarId equals c.CarId
                    join m in context.Customers on r.CustomerId equals m.Id
                    join u in context.Users on m.UserId equals u.Id
                    join b in context.Brands on c.BrandId equals b.BrandId
                    select new RentDetailDto()
                    {
                        Car = b.BrandName+" "+c.Descriptions,
                        Customer = u.FirstName+" "+u.LastName,
                        DailyPrice = c.DailyPrice,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate
                    };
                return result.ToList();
            }
        }
    }
}
