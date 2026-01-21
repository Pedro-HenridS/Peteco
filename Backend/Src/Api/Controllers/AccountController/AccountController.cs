using Domain.Dtos.Requests.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AccountController
{
    public class AccountController : Controller
    {
        [Route("/login")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {



            return Ok();
        }
    }
}
