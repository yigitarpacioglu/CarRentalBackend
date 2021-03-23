using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ReCapProject.Core.DataAccess;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.DataAccess.Abstract
{
    public interface ICustomerDal: IEntityRepository<Customer>
    {
        List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null);
    }
}
