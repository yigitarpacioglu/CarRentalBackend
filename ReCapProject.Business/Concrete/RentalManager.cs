using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.Business.Concrete
{
    public class RentalManager:IRentalService
    {
        private IRentalDal _rentalDal;
        private int hour=03;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAllService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<Rental>>(GeneralMessages.Maintenance);
            }

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), RentalMessages.RentalListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<Rental>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id==id), RentalMessages.RentalListed);
        }

        public IResult AddService(Rental entity)
        {
            var rentalList = _rentalDal.GetAll(r => r.CarId == entity.CarId);

            foreach (var car in rentalList)
            {
                if (car.ReturnDate==null)
                {
                    return new ErrorResult(RentalMessages.RentalReturnDateError);
                }
            }
            _rentalDal.Add(entity);
            return new SuccessResult(RentalMessages.RentalAdded);
        }

        public IResult UpdateService(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(RentalMessages.RentalUpdated);
        }

        public IResult DeleteService(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(RentalMessages.RentalDeleted);
        }

        public IDataResult<List<RentDetailDto>> GetRentalDetails()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<RentDetailDto>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<RentDetailDto>>(_rentalDal.GetRentalDetails(), RentalMessages.RentalListed);
        }

    }
}
