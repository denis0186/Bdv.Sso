using Bdv.DataAccess;
using Bdv.Sso.Common;
using Bdv.Sso.Domain.Entities;

namespace Bdv.Sso.Commands.Account
{
    public class UserLoginByLoginRequestHandler : UserLoginByPasswordRequestHandlerBase<UserLoginByLoginRequest>
    {
        private readonly IRepository _repository;

        public UserLoginByLoginRequestHandler(
            IRepository repository,
            IPasswordHasher passwordHasher,
            ITokenGenerator tokenGenerator)
            : base(passwordHasher, tokenGenerator)
        {
            _repository = repository;
        }

        protected override Task<User?> GetUserAsync(UserLoginByLoginRequest request)
        {
            return _repository.GetAsync<User>(x => x.Login == request.Login);
        }

        protected override Exception GetUserOrPasswordNotFoundException()
        {
            return new ArgumentException("User login or password is wrong");
        }
    }
}
