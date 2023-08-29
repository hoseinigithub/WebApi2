using Application.Services.Users.Commands.DeleteUser;
using Application.Services.Users.Commands.RegisterUser;
using Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRegisterUserService _registerUser;

        private readonly IGetUsersService _getUsers;
        private readonly IDeleteUserService _deleteUser;

        public UsersController(IRegisterUserService registerUser, IGetUsersService getUsers, IDeleteUserService deleteUser)
        {
            _registerUser = registerUser;
            _getUsers = getUsers;
            _deleteUser = deleteUser;
        }

        [HttpPost]
        public async Task<ActionResult> Add(RequestRegisterUserDto request)
        {
            var result = await _registerUser.Execute(request);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _getUsers.Execute();

            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _deleteUser.Execute(id);

            return StatusCode(result.StatusCode, result);
        }
    }
}