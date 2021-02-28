using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Core;
using ReCapProject.Core.Entites.Concrete;

namespace ReCapProject.Core.Utilities.Security.Jwt
{
    // Helper for Token Generation: According to changibility for token format changes, it's going to be interface
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);

    }
}
