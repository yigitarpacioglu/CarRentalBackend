using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entites.Concrete;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Core.Utilities.Security.Jwt;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
