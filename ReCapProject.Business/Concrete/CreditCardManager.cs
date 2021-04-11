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
    public class CreditCardManager:ICreditCardService
    {

        private ICreditCardDal _creditCardDal;
        private int hour = Values.hour;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IDataResult<List<CreditCard>> GetAllService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<CreditCard>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(), CreditCardMessages.CreditCardsListed);
        }

        public IDataResult<CreditCard> GetById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<CreditCard>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.Id == id),
                CreditCardMessages.CreditCardsListed);
        }

        public IResult AddService(CreditCard entity)
        {
            _creditCardDal.Add(entity);
            return new SuccessResult(CreditCardMessages.CreditCardAdded);
        }

        public IResult UpdateService(CreditCard entity)
        {
            _creditCardDal.Update(entity);
            return new SuccessResult(CreditCardMessages.CreditCardUpdated);
        }

        public IResult DeleteService(CreditCard entity)
        {
            _creditCardDal.Delete(entity);
            return new SuccessResult(CreditCardMessages.CreditCardDeleted);
        }

        public IDataResult<CreditCard> GetByCvc(string cvc)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.CVC == cvc));
        }
    }
}
