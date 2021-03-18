using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.DataAccess.Concrete.EntityFramework;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;
        private int hour = Values.hour;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAllService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<Brand>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), BrandMessages.BrandListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<Brand>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == id), BrandMessages.BrandListed);
            
        }

        public IResult AddService(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccessResult(BrandMessages.BrandAdded);
        }

        public IResult UpdateService(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult(BrandMessages.BrandUpdated);
        }

        public IResult DeleteService(Brand entity)
        {
            _brandDal.Delete(entity);
            return new SuccessResult(BrandMessages.BrandDeleted);
        }
    }

}
