using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfCreditCardDal:EfEntityRepositoryBase<CreditCard,CarRentalDbContext>, ICreditCardDal
    {
    }
}
