using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.DataAccess;
using ReCapProject.Core.Entites.Concrete;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
