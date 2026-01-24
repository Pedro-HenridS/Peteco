using Application.UseCases.CreateUser;
using Domain.Dtos.Requests.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AccountController
{
    public class AccountController : Controller
    {

        private CreateUserUseCase _createUserUseCase;
        public AccountController(
            CreateUserUseCase createUserUseCase
        )
        {
            _createUserUseCase = createUserUseCase;
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            await _createUserUseCase.Execute(request);


            return Ok();
        }
    }
}
