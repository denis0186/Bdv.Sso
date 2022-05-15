using Bdv.Authentication.Attributes;
using Bdv.Domain.Dto.Sso;
using Bdv.Sso.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bdv.Sso.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Retrieve users list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Sso.Users.GetUsers")]
        public Task<IEnumerable<UserDto>> GetUsers([FromQuery] GetUsersRequest request)
        {
            return _mediator.Send(request);
        }

        [HttpGet("{id}")]
        [Authorize("Sso.Users.GetUser")]
        public Task<UserDto> GetUser([FromRoute] Guid id)
        {
            return null;
        }
    }
}
