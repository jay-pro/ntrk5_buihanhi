using ecommerceweb.API.Models.Enums;

namespace ecommerceweb.API.Models.Authenticate
{
    public partial class AuthenticateResponse
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public AccountRole Role { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string Token { get; set; }
        public AuthenticateResponse(Account account, string token)
        {
            AccountId = account.AccountId;
            Username = account.Username;
            Role = account.Role;
            Fullname = account.Fullname;
            Email = account.Email;
            Phone = account.Phone;
            Address = account.Address;
            Avatar = account.Avatar;
            Token = token;
        }
    }
}
