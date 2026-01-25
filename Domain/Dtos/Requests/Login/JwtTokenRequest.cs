namespace Domain.Dtos.Requests.Login
{
    public class JwtTokenRequest
    {
        public string Username { get; set; }
        public Guid UserId { get; set; }
        public List<string> Roles { get; set; }
    }
}
