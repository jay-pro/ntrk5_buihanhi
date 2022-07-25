using AutoMapper;
using ecommerceweb.API.Models;
using ecommerceweb.SharedModel;
using ecommerceweb.SharedModel.Authenticate;

namespace ecommerceweb.API.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>();
            CreateMap<AccountDTO, Account>().ReverseMap();
            CreateMap<RegisterRequestDTO, AccountDTO>();
        }
    }
}
