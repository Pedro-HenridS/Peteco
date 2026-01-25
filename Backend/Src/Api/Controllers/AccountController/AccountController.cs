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


            return Ok();
        }
    }
}
