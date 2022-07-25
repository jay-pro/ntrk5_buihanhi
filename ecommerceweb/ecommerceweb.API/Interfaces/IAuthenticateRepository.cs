using ecommerceweb.API.Models;
using ecommerceweb.SharedModel;
using ecommerceweb.SharedModel.Authenticate;

namespace ecommerceweb.API.Interfaces
{
    public interface IAuthenticateService
    {
        AuthenticateResponseDTO Authenticate(AuthenticateRequestDTO model);
        AccountDTO Register(RegisterRequestDTO model);
        IEnumerable<AccountDTO> GetAll();
        AccountDTO GetById(int accountId);

    }
}
