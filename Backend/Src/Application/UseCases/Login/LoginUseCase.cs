using Domain.Contracts.Providers;
using Domain.Contracts.Services;
using Domain.Dtos.Requests.Login;


namespace Application.UseCases.Login
{
    public class LoginUseCase
    {

        private readonly IJwtProvider _jwtProvider;
        private readonly IUserService _userService;

        public LoginUseCase(
            IJwtProvider jwtProvider,
            IUserService userService
        )
        {
            _userService = userService;
            _jwtProvider = jwtProvider;
        }

        public async Task<string?> Execute(LoginRequest request)
        {
            var userId = await _userService.VerifyLogin(request);

            if (userId == Guid.Empty)
                throw new Exception("Invalid email or password.");

            var userClaims = await _userService.GetUserClaims(userId);

            if (userClaims.UserId == Guid.Empty)
                return null;

            var jwtToken = _jwtProvider.GenerateToken(userClaims);


            return jwtToken;
        }

        //Verifica existência do usuário e senha no banco de dados
        //Resgatar role, id e nome
        // Gera um token JWT
        // Guarda o token na resposta
    }
}
