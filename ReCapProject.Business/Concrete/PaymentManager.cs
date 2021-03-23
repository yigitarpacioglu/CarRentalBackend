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
    public class PaymentManager:IPaymentService
    {
        private IPaymentDal _paymentDal;
        private ICustomerService _customerService;

        private int hour = Values.hour;

        public PaymentManager(IPaymentDal paymentDal, ICustomerService customerService)
        {
            _paymentDal = paymentDal;
            _customerService = customerService;
        }

        public IDataResult<List<Payment>> GetAllService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<Payment>>(GeneralMessages.Maintenance);
            }

            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(), PaymentMessages.PaymentListed);
        }

        public IDataResult<Payment> GetById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<Payment>(GeneralMessages.Maintenance);
            }

            return new SuccessDataResult<Payment>(_paymentDal.Get(p=>p.Id==id), PaymentMessages.PaymentListed);
        }

        public IResult AddService(Payment entity)
        {
            _paymentDal.Add(entity);
            return new SuccessResult(PaymentMessages.PaymentAdded);
        }

        public IResult UpdateService(Payment entity)
        {
            _paymentDal.Update(entity);
            return new SuccessResult(PaymentMessages.PaymentUpdated);
        }

        public IResult DeleteService(Payment entity)
        {
            _paymentDal.Delete(entity);
            return new SuccessResult(PaymentMessages.PaymentDeleted);
        }

        public IResult CashTransaction(RentOrderDto rentOrder)
        {
            var customer = _customerService.GetById(rentOrder.Rental.CustomerId);
            if (customer.Data.Balance < rentOrder.Payment.Amount)
            {
                return new ErrorResult(PaymentMessages.InsufficientFund);
            }
            customer.Data.Balance -= rentOrder.Payment.Amount;

            return new SuccessResult(PaymentMessages.PaymentSuccessful);
        }
    }
}
