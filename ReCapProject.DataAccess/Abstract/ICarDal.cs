using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ReCapProject.Core.DataAccess;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
        CarDetailDto GetCarDetailsById(Expression<Func<CarDetailDto, bool>> filter); 
        // List<CarDetailDto> GetCarDetailsByColorName(Expression<Func<CarDetailDto, bool>> filter);
    }
}
