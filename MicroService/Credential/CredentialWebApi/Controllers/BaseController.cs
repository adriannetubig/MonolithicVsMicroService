using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace CredentialWebApi.Controllers
{
    [EnableCors("CORS")]
    [Route("api/[controller]")]
    [Authorize, ApiController]
    public class BaseController : ControllerBase
    {
        protected virtual string UserName => User.Identities.FirstOrDefault().Name;
        protected virtual int LoginId => Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
    }
}