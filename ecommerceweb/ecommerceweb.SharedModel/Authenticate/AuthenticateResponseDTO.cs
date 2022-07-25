using ecommerceweb.SharedModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceweb.SharedModel.Authenticate
{
    public partial class AuthenticateResponseDTO
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public AccountRole Role { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address   { get; set; }
        public string Avatar { get; set; }
        public string Token { get; set; }
        public AuthenticateResponseDTO(AccountDTO account, string token)
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
