using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalDbContext>, IRentalDal
    {
        public List<RentDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                    join c in context.Cars on r.CarId equals c.CarId
                    join m in context.Customers on r.CustomerId equals m.Id
                    join u in context.Users on m.UserId equals u.Id
                    join b in context.Brands on c.BrandId equals b.BrandId
                    select new RentDetailDto()
                    {
                        CarId = c.CarId,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate,
                        RentalId = r.Id
                    };
                return result.ToList();
            }
        }
    }
}
