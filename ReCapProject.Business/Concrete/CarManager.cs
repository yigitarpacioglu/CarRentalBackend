using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using Business.BusinessAspects.Autofac;
using FluentValidation;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Business.ValidationRules.FluentValidation;
using ReCapProject.Core.Aspects.Autofac.Caching;
using ReCapProject.Core.Aspects.Autofac.Validation;
using ReCapProject.Core.CrossCuttingConcerns.Validation;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.Business.Concrete
{
    public class CarManager : ICarService
    {
        private int hour = 03;
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        
        
        [CacheAspect]
        public IDataResult<List<Car>> GetAllService()
        {
            
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<Car>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), CarMessages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<Car>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id), CarMessages.CarsListed);

        }

        //[SecuredOperation("car.add")]
        //[ValidationAspect(typeof(CarValidator))]
        //[CacheRemoveAspect("ICarService.Get")]
        public IResult AddService(Car entity)
        {
            ValidationTool.Validate(new CarValidator(), entity);
            _carDal.Add(entity);
            return new SuccessResult(CarMessages.CarAdded);
        }

        public IResult UpdateService(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(CarMessages.CarUpdated);
        }

        public IResult DeleteService(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(CarMessages.CarDeleted);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<CarDetailDto>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), CarMessages.CarsListed);
        }

        public IDataResult<CarDetailDto> GetCarDetailsByIdService(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<CarDetailDto>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsById(c => c.CarId == id), CarMessages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<CarDetailDto>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=>c.ColorName==colorName), CarMessages.CarsListed);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<CarDetailDto>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandName == brandName), CarMessages.CarsListed);
        }
    }
}
