using System.Threading.Tasks;
using AxonCFS.Application.BindingModels;
using AxonCFS.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AxonCFS.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Login using username and password.
        /// </summary>
        /// <param name="model">Login model.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginBindingModel model)
        {
            return Ok();
        }
    }
}
