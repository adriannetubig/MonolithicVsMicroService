using CredentialBusiness.Interfaces;
using CredentialModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CredentialWebApi.Controllers
{
    public class AuthenticationsController : BaseController
    {
        private readonly IBAuthentications _iBAuthentications;
        private readonly IBLogins _iBLogins;
        public AuthenticationsController(IBAuthentications iBAuthentications, IBLogins iBLogins)
        {
            _iBAuthentications = iBAuthentications;
            _iBLogins = iBLogins;
        }

        [AllowAnonymous, HttpPost, Route("")]
        public async Task<IActionResult> Authenticate([FromBody]Login login)
        {
            login = await _iBLogins.Authenticate(login);
            if (login.LoginId <= 0)
                return Unauthorized();

            return Ok(_iBAuthentications.Create(login));
        }
    }
}