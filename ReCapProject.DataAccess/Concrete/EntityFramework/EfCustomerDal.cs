using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,CarRentalDbContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result = from c in context.Customers
                    join u in context.Users on c.UserId equals u.Id
                    select new CustomerDetailDto()
                    {
                        Id = c.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        CompanyName = c.CompanyName,
                        Balance = c.Balance
                        
                    };
                return result.ToList();
            }
        }

        public CustomerDetailDto GetCustomerDetailsById(Expression<Func<Customer, bool>> filter)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                
                    var result = from c in filter == null ? context.Customers : context.Customers.Where(filter) 
                        join u in context.Users on c.UserId equals u.Id
                    select new CustomerDetailDto()
                    {
                        Id = c.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        CompanyName = c.CompanyName,
                        Balance = c.Balance

                    };
                return result.SingleOrDefault();
            }
        }
    }
}
