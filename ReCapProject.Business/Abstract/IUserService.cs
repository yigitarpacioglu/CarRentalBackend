using System;
using ReCapProject.Core.Entites.Concrete;
using ReCapProject.Core.Utilities.Results;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Utilities.Business;


namespace ReCapProject.Business.Abstract
{
    public interface IUserService:ICrudServices<User>
    {
        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IResult findexOps(int userId, int carId);
    }
}
