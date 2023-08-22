using System.ComponentModel.DataAnnotations;

namespace Application.Services.Users.Commands.RegisterUser;

public class RequestRegisterUserDto
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PostalCode { get; set; }
    public string? BuildingNumber { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public List<int> RoleId { get; set; }
}