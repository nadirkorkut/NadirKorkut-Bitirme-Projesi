using SiteManager.Business.DTOs;
using SiteManager.Core.Utilities.Results;
using SiteManager.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManager.Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<UserDto>>> GetAll();
        Task<IResult> CreateUser(RegisterDto registerDto);
        Task<IResult> UpdateUser(UserDto userDto);
        IResult DeleteUser(string id);
        User GetUserSession();
        Task<IResult> AddRole(RegisterDto registerDto,string role);
        Task<IDataResult<UserDto>> GetById(string id);
    }
}
