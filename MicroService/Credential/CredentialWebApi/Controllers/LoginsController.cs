using System.Threading.Tasks;
using CredentialBusiness.Interfaces;
using CredentialModel;
using Microsoft.AspNetCore.Mvc;

namespace CredentialWebApi.Controllers
{
    public class LoginsController : BaseController
    {
        private readonly IBLogins _iBLogins;

        public LoginsController(IBLogins iBLogins)
        {
            _iBLogins = iBLogins;
        }

        [HttpPut, Route("")]
        public async Task<IActionResult> Create([FromBody]Login login)
        {
            await _iBLogins.Create(login, LoginId);
            return StatusCode(201);
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> Read()
        {
            var logins = await _iBLogins.Read();
            return Ok(logins);
        }

        [HttpGet, Route("{loginId}")]
        public async Task<IActionResult> Read(int loginId)
        {
            var login = await _iBLogins.Read(loginId);
            return Ok(login);
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Update([FromBody]Login login)
        {
            await _iBLogins.Update(login, LoginId);
            return Ok();
        }

        [HttpDelete, Route("{loginId}")]
        public async Task<IActionResult> Delete(int loginId)
        {
            await _iBLogins.Delete(loginId, LoginId);
            return NoContent();
        }
    }
}