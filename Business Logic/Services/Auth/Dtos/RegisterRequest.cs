namespace Business_Logic.Services.Auth.Dtos
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
