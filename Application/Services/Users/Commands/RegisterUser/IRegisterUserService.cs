using Application.Interfaces.Contexts;
using Common;
using Domain.Entities.Users;

namespace Application.Services.Users.Commands.RegisterUser;

public interface IRegisterUserService
{
    Task<ResultDto> Execute(RequestRegisterUserDto request);
}

public class RegisterUserService : IRegisterUserService
{
    private readonly IDatabaseContext _context;

    public RegisterUserService(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<ResultDto> Execute(RequestRegisterUserDto request)
    {
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

public class RequestRegisterUserDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PostalCode { get; set; }
    public string BuildingNumber { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}