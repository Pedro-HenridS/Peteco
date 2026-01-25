using Application.UseCases.CreateUser;
using Domain.Dtos.Requests.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AccountController
{
    [ApiController]
    [Route("/[controller]")]
    public class AccountController : ControllerBase
    {

        private CreateUserUseCase _createUserUseCase;
        public AccountController(
            CreateUserUseCase createUserUseCase
        )
        {
            _createUserUseCase = createUserUseCase;
        }

        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            await _createUserUseCase.Execute(request);


            return Ok();
        }
    }
}
