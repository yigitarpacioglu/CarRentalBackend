using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.Core.Entites.Concrete;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User, CarRentalDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarRentalDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join UserOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals UserOperationClaim.OperationClaimId
                    where UserOperationClaim.UserId == user.Id
                    select new OperationClaim {Id = operationClaim.Id, Name = operationClaim.Name};
                return result.ToList(); 
            }
        }
    }
}
