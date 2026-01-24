using Domain.Contracts.Services;
using Domain.Dtos.Requests.CreateUser;

namespace Application.UseCases.CreateUser
{
    public class CreateUserUseCase
    {

        private IUserService _userService;
        public CreateUserUseCase(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Execute(CreateUserRequest request)
        {
            await _userService.CreateUserRotine(request);
        }

        // Verificar validade dos dados de lCogin
        // Verificar se email já existe
        // Salvar usuário no banco de dados
        // Retornar resposta adequada

    }
}
