using Bdv.Domain.Dto.Sso;
using Bdv.Sso.Common;
using Bdv.Sso.Domain.Entities;
using MediatR;

namespace Bdv.Sso.Commands.Account
{
    public abstract class UserLoginByPasswordRequestHandlerBase<TRequest> : IRequestHandler<TRequest, TokenDto>
        where TRequest : UserLoginByPasswordRequestBase
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenGenerator _tokenGenerator;

        protected UserLoginByPasswordRequestHandlerBase(
            IPasswordHasher passwordHasher,
            ITokenGenerator tokenGenerator)
        {
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<TokenDto> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var user = await GetUserAsync(request)
                ?? throw GetUserOrPasswordNotFoundException();

            if (!_passwordHasher.ValidatePassword(request.Password, user.PasswordSalt, user.Password))
            {
                throw GetUserOrPasswordNotFoundException();
            }

            return new TokenDto { AccessToken = await _tokenGenerator.GenerateTokenAsync(user) };
        }

        protected abstract Task<User> GetUserAsync(TRequest request);

        protected abstract Exception GetUserOrPasswordNotFoundException();
    }
}
