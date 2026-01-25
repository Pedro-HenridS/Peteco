using Domain.Dtos.Requests.Login;

namespace Domain.Contracts.Providers
{
    public interface IJwtProvider
    {
        public string GenerateToken(JwtTokenRequest request);
    }
}
