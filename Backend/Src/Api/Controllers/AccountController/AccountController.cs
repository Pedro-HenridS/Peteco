using Application.UseCases.CreateUser;
using Application.UseCases.Login;
using Domain.Dtos.Requests.CreateUser;
using Domain.Dtos.Requests.Login;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AccountController
{
    [ApiController]
    [Route("/[controller]")]
    public class AccountController : ControllerBase
    {

        private CreateUserUseCase _createUserUseCase;
        private LoginUseCase _loginUseCase;

        public AccountController(
            CreateUserUseCase createUserUseCase,
            LoginUseCase loginUseCase
        )
        {
            _createUserUseCase = createUserUseCase;
            _loginUseCase = loginUseCase;
        }

        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            await _createUserUseCase.Execute(request);

            return Ok();
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var jwtToken = await _loginUseCase.Execute(request);

            if (jwtToken is null)
                throw new Exception("Invalid email or password.");

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(2),
                Path = "/"
            };

            Response.Cookies.Append("access_token", jwtToken, cookieOptions);

            return Ok();
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("access_token");
            return Ok();
        }

    }
}
