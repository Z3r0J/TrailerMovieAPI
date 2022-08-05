using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrailerMovieAPI.Core.Application.DTOS.Account;
using TrailerMovieAPI.Core.Application.Interfaces.Services;
using System.Threading.Tasks;

namespace TrailerMovieAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices _accountServices;

        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request) {


            return Ok(await _accountServices.AuthenticateAsync(request));
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpPost("register-administrator")]
        public async Task<IActionResult> RegisterAdministratorAsync(RegisterRequest request) {

            return Ok(await _accountServices.RegisterAdministratorAsync(request));
        }

    }
}
