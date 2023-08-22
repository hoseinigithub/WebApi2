using Application.Interfaces.Contexts;
using Common;
using CryptoHelper;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Application.Services.Users.Commands.RegisterUser;

public class RegisterUserService : IRegisterUserService
{
    private readonly IDatabaseContext _context;

    public RegisterUserService(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<ResultDto> Execute(RequestRegisterUserDto request)
    {
        if (string.IsNullOrEmpty(request.FullName))
        {
            return new ResultDto
            {
                IsSucces = false,
                StatusCode = 400,
                Message = "The fullname is required!"
            };
        }

        /// Add User
        User user = new User()
        {
            FullName = request.FullName,
            Address = request.Address,
            BuildingNumber = request.BuildingNumber,
            Email = request.Email,
            Password = Crypto.HashPassword(request.Password),
            PhoneNumber = request.PhoneNumber,
            PostalCode = request.PostalCode,
        };

        List<UserInRole> userInRoleList = new List<UserInRole>();

        foreach (var role in request.RoleId)
        {
            var RequestRole = _context.Roles.Find(role);

            if (RequestRole == null)
            {
                return new ResultDto
                {
                    IsSucces = false,
                    Message = "The selected role was not found",
                    StatusCode = 404
                };
            }
            userInRoleList.Add(new UserInRole { UserId = user.Id, RoleId = role });
        }

        user.UserInRoles = userInRoleList;

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return new ResultDto
        {
            IsSucces = true,
            Message = "Registration Successfully",
            StatusCode = 200
        };
    }
}