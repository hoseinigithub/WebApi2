using Common;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsersService
    {
        Task<ResultDto<List<ResponseGetUsersDto>>> Execute();
    }
}