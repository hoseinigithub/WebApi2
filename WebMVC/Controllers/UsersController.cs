using Application.Services.Users.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRegisterUserService _registerUser;

        public UsersController(IRegisterUserService registerUser)
        {
            _registerUser = registerUser;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(RequestRegisterUserDto request)
        {
            var result = await _registerUser.Execute(request);

            return Json(result);
        }
    }
}