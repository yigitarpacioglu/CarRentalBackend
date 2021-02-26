using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Utilities.Business;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.Abstract
{
    public interface ICarImageService:ICrudServices<CarImage>
    {
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}
