using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.Abstract
{
    public interface IFakeBankService
    {
        IResult CashTransaction(Payment payment);

        IResult UpdateBalance(Payment payment);
    }
}
