using Application.Services.Users.Commands.RegisterUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRegisterUserService _registerUser;

        public UsersController(IRegisterUserService registerUser)
        {
            _registerUser = registerUser;
        }

        [HttpPost]
        public async Task<ActionResult> Add(RequestRegisterUserDto request)
        {
            var result = await _registerUser.Execute(request);

            return StatusCode(200, result);
        }
    }
}