using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ReCapProject.Core.DataAccess;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.DataAccess.Abstract
{
    public interface IRentalDal: IEntityRepository<Rental>
    {
        List<RentDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null);
    }
}
