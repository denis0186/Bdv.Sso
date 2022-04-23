using Bdv.Domain.Dto.Sso;
using MediatR;

namespace Bdv.Sso.Commands.Account
{
    public abstract class UserLoginByPasswordRequestBase : IRequest<TokenDto>
    {
        /// <summary>
        /// User password
        /// </summary>
        public string? Password { get; set; }
    }
}
