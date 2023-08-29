using Application.Interfaces.Contexts;
using Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDatabaseContext _context;

        public GetUsersService(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<List<ResponseGetUsersDto>>> Execute()
        {
            var result = await _context.Users.Select(r => new ResponseGetUsersDto
            {
                Address = r.Address,
                BuildingNumber = r.BuildingNumber,
                Email = r.Email,
                FullName = r.FullName,
                Id = r.Id,
                PhoneNumber = r.PhoneNumber,
                PostalCode = r.PostalCode,
                Roles = r.UserInRoles.Select(u => new RoleDto
                {
                    RoleId = u.RoleId,
                    Name = u.Role.Name
                }).ToList()
            }).OrderByDescending(g => g.Id).ToListAsync();

            return new ResultDto<List<ResponseGetUsersDto>>
            {
                Data = result,
                IsSucces = true,
                StatusCode = 200
            };
        }
    }
}