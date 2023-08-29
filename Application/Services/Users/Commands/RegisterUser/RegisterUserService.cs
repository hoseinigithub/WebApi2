using Application.Interfaces.Contexts;
using Common;
using Domain.Entities.Users;

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
        if (!request.Password.Equals(request.RePassword))
        {
            return new ResultDto
            {
                IsSucces = false,
                Message = "Password and Repassword Not Equal!",
                StatusCode = 400
            };
        }

        /// Add User
        User user = new User()
        {
            FullName = request.FullName,
            Address = request.Address,
            BuildingNumber = request.BuildingNumber,
            Email = request.Email,
            Password = request.Password,
            PhoneNumber = request.PhoneNumber,
            PostalCode = request.PostalCode
        };

        List<UserInRole> userInRoles = new List<UserInRole>();

        foreach (var roleId in request.RoleId)
        {
            if (_context.Roles.Any(u => u.Id == roleId))
            {
                userInRoles.Add(new UserInRole { UserId = user.Id, RoleId = roleId });
            }
            else
            {
                return new ResultDto
                {
                    IsSucces = false,
                    StatusCode = 404,
                    Message = "The selected role was not found"
                };
            }
        }
        user.UserInRoles = userInRoles;
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