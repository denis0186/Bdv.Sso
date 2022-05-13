using Bdv.Domain.Dto.Sso;
using Bdv.Sso.Commands.Account;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bdv.Sso.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// LogIn by user login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public Task<TokenDto> Login(UserLoginByLoginRequest request)
        {
            return _mediator.Send(request);
        }
    }
}
