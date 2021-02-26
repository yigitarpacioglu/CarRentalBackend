using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Core.Utilities.Business;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        private ICarImageDal _carImageDal;
        private int hour=03;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAllService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<CarImage>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), CarImageMessages.CarImageListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<CarImage>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.CarId==id), CarImageMessages.CarImageListed);
        }

        public IResult AddService(CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckIfTotalImageForCarExceed(entity.CarId));

            if (result != null)
            {
                return result;
            }
            
            _carImageDal.Add(entity);
            return new SuccessResult(CarImageMessages.CarImageAdded);
        }

        public IResult UpdateService(CarImage entity)
        {
            _carImageDal.Update(entity);
            return new SuccessResult(CarImageMessages.CarImageUpdated);
        }

        public IResult DeleteService(CarImage entity)
        {
            _carImageDal.Delete(entity);
            return new SuccessResult(CarImageMessages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            string defaultPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName +
                                 "\\Assets\\default.png";
            var query = _carImageDal.GetAll(c => c.CarId == carId);
            if (query.Count!=0)
            {
                return new SuccessDataResult<List<CarImage>>(query);
            }
            return new SuccessDataResult<List<CarImage>>(new List<CarImage>
                {new CarImage {CarId = carId, ImagePath = defaultPath}});
            
        }

        private IResult CheckIfTotalImageForCarExceed(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result>5)
            {
                return new ErrorResult(CarImageMessages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

        //private string GenerateNewPath()
        //{
        //    string basePath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName;
        //    string key = Guid.NewGuid().ToString();
        //    string fullPath = basePath + "\\Assets\\" + key + ".png" ;
        //    return fullPath;
        //}
        
    }
}
