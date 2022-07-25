using AutoMapper;
using ecommerceweb.API.Authorization;
using ecommerceweb.API.Interfaces;
using ecommerceweb.SharedModel;
using ecommerceweb.SharedModel.Authenticate;
using ecommerceweb.SharedModel.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceweb.API.Controllers
{
    [Authorize]
    /*[Authorization]*/
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private IAuthenticateService _service;
        private IAccountRepository _account;
        private readonly IMapper _mapper;

        public AccountsController(IAuthenticateService service, IAccountRepository account, IMapper mapper)
        {
            _service = service;
            _account = account;
            _mapper = mapper;
        }

        //Allow Anonymous
        [@AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Register(RegisterRequestDTO model)
        {
            var response = _service.Register(model);
            return Ok(response);
        }//Register failedd

        [@AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult Authenticate(AuthenticateRequestDTO model)
        {
            var response = _service.Authenticate(model);
            return Ok(response);
        }

        //
        [HttpGet("Admin")]
        //[Authorize(AccountRole.Admin)]
        public IActionResult GetAll()
        {
            var accounts = _service.GetAll();
            return Ok(accounts);
        }

        //Admin
        [HttpGet("{AccountId:int}")]
        public IActionResult GetById(int AccountId)
        {
            var currentAccount = (AccountDTO)HttpContext.Items["Account"];
            if (AccountId != currentAccount.AccountId && currentAccount.Role != AccountRole.Admin)
            {
                return Unauthorized(new { message = "Unauthorized" });
            }

            var account = _service.GetById(AccountId);
            return Ok(account);
        }

        [@AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var getAccounts = await _account.GetAsync();
                if (!getAccounts.Any())
                {
                    return NotFound("There's no account.");
                }
                var accountDTO = _mapper.Map<List<AccountDTO>>(getAccounts);
                return Ok(accountDTO);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }











        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
