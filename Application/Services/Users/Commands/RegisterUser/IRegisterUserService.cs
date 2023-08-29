using Common;

namespace Application.Services.Users.Commands.RegisterUser;

public interface IRegisterUserService
{
    Task<ResultDto> Execute(RequestRegisterUserDto request);
}