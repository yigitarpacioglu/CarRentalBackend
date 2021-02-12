using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.DataAccess;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
    }
}
