using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AxonCFS.Api.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected string GetUserId()
        {
            var claims = User.Identity as ClaimsIdentity;
            return claims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}