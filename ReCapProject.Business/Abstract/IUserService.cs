using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entites.Concrete;
using ReCapProject.Core.Utilities.Business;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.Abstract
{
    public interface IUserService:ICrudServices<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
