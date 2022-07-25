using AutoMapper;
using ecommerceweb.API.Authorization;
using ecommerceweb.API.Data;
using ecommerceweb.API.Helpers;
using ecommerceweb.API.Interfaces;
using ecommerceweb.API.Models;
using ecommerceweb.API.Models.Enums;
using ecommerceweb.SharedModel;
using ecommerceweb.SharedModel.Authenticate;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
//using ServiceStack.Auth;//

namespace ecommerceweb.API.Services
{
    public class Service : IAuthenticateService
    {
        private APIDbContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        
        public Service(APIDbContext context, IJwtUtils jwtUtils, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public AuthenticateResponseDTO Authenticate(AuthenticateRequestDTO model)
        {
            try
            {
                var account = _context.Accounts.SingleOrDefault(x => x.Username == model.Username);
                //Validate
                if (account == null || !BCrypt.Net.BCrypt.Verify(model.Password, account.Password))
                    return null;
                var accountDto = _mapper.Map<AccountDTO>(account);
                //Authentication -> jwt token
                var jwtToken = _jwtUtils.GenerateJwtToken(accountDto);
                return new AuthenticateResponseDTO(accountDto, jwtToken);
            }
            catch
            {
                return null;
            }
        }
        public AccountDTO Register(RegisterRequestDTO model)
        {
            try
            {
                var accountDto = _mapper.Map<AccountDTO>(model);

                accountDto.Role = (SharedModel.Enums.AccountRole)AccountRole.Customer;
                accountDto.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

                var x = _mapper.Map<Account>(accountDto);

                _context.Accounts.Add(x);
                _context.SaveChanges();
                return accountDto;
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<AccountDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<AccountDTO>>(_context.Accounts);
        }
        public AccountDTO GetById(int accountId)
        {
            var account = _context.Accounts.Find(accountId);
            var accountDto = _mapper.Map<AccountDTO>(account);
            if(accountDto == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return accountDto;
        }
    }
}
