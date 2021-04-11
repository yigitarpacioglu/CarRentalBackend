using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entites.Concrete;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;
        private ICarService _carService;
        private int hour=Values.hour;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAllService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<User>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), UserMessages.UserListed);
        }

        public IDataResult<User> GetById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<User>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id==id), UserMessages.UserListed);
        }

        public IResult AddService(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(UserMessages.UserAdded);
        }

        public IResult UpdateService(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(UserMessages.UserUpdated);
        }

        public IResult DeleteService(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(UserMessages.UserDeleted);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IResult findexOps(int userId, int carId)
        {
            User user = GetById(userId).Data;
            Car car = _carService.GetById(carId).Data;

            if (user.Findex > 1900) {
                return new ErrorResult(UserMessages.FindexLimitIsExceed);
            }
            if (user.Findex<car.Findex)
            {
                return new ErrorResult(UserMessages.FindexNotEnough);
            }
            user.Findex += 125;
            UpdateService(user);
            return new SuccessResult(UserMessages.FindexIncreased);
        }
    }
}
