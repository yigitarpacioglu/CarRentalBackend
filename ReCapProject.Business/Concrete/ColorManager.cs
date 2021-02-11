using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.Concrete
{
    public class ColorManager:IColorService
    {
        private IColorDal _colorDal;
        private int hour=04;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAllService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<Color>>(ColorMessages.Maintenance);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), ColorMessages.ColorsListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<Color>(ColorMessages.Maintenance);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id), ColorMessages.ColorsListed);
        }

        public IResult AddService(Color entity)
        {
            _colorDal.Add(entity);
            return new SuccessResult(ColorMessages.ColorAdded);
        }

        public IResult UpdateService(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult(ColorMessages.ColorUpdated);
        }

        public IResult DeleteService(Color entity)
        {
            _colorDal.Delete(entity);
            return new SuccessResult(ColorMessages.ColorDeleted);
        }
    }
}
