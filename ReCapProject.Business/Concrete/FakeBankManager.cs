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
    public class FakeBankManager:IFakeBankService
    {
        private int hour = Values.hour;
        private ICreditCardService _creditCardService;
        private ICreditCardDal _creditCardDal;

        public FakeBankManager(ICreditCardService creditCardService, ICreditCardDal creditCardDal)
        {
            _creditCardService = creditCardService;
            _creditCardDal = creditCardDal;
        }

        public IResult CashTransaction(Payment payment)
        {
            var card = IsCardExist(payment.CreditCard).Data;
            if (card.Balance < payment.Amount)
            {
                return new ErrorResult(PaymentMessages.InsufficientFund);
            }
            else
            {
                card.Balance -= payment.Amount;
                _creditCardService.UpdateService(card);
                return new SuccessResult(PaymentMessages.PaymentSuccessful);

                //var creditCardToUpdate = new CreditCard
                //{
                //    Id = card.Id,
                //    Balance = card.Balance - payment.Amount,
                //    LastName = card.LastName,
                //    FirstName = card.FirstName,
                //    CVC = card.CVC,
                //    CardNumber = card.CardNumber,
                //    ExpirationDate = card.ExpirationDate,
                //    UserId = card.UserId,
                //};
                // _creditCardService.UpdateService(creditCardToUpdate);

            }
        }

        public IDataResult<CreditCard> IsCardExist(CreditCard creditCard)
        {
            var card = _creditCardService.GetByCvc(creditCard.CVC);
            if (!card.Success)
            {
                return new ErrorDataResult<CreditCard>(PaymentMessages.CardNotExist);
            }
            return card;
        }

        public IResult UpdateBalance(Payment payment)
        {
            var card = IsCardExist(payment.CreditCard).Data;
            card.Balance += payment.Amount;
            _creditCardService.UpdateService(card);
            return new SuccessResult(PaymentMessages.BalanceUpdated);

        }
    }
}
