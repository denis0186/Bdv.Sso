using Bdv.DataAccess;
using Bdv.Domain.Dto.Sso;
using Bdv.Redis;
using Bdv.Sso.Common;
using Bdv.Sso.Domain.Dto;
using Bdv.Sso.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bdv.Sso.Commands.Account
{
    public abstract class UserLoginByPasswordRequestHandlerBase<TRequest> : IRequestHandler<TRequest, TokenDto>
        where TRequest : UserLoginByPasswordRequestBase
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IRedisRepository _redisRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IRepository _repository;

        protected UserLoginByPasswordRequestHandlerBase(
            IPasswordHasher passwordHasher,
            ITokenGenerator tokenGenerator,
            IRepository repository,
            IRedisRepository redisRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
            _repository = repository;
            _redisRepository = redisRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TokenDto> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var user = await GetUserAsync(request)
                ?? throw GetUserOrPasswordNotFoundException();
            
            if (!_passwordHasher.ValidatePassword(request.Password, user.PasswordSalt, user.Password))
            {
                throw GetUserOrPasswordNotFoundException();
            }

            var userRoles = await _repository.GetAllAsync<UserRole>(x => x.UserId == user.Id);
            var roleIds = userRoles.Select(x => x.RoleId).ToList();
            var rolesTask = _repository.GetAllAsync<Role>(x => roleIds.Contains(x.Id));
            var rolePermissionsTask = _repository.GetAllAsync<RolePermission>(x => roleIds.Contains(x.RoleId));

            await Task.WhenAll(rolesTask, rolePermissionsTask);

            var roles = rolesTask.Result;
            var permissionIds = rolePermissionsTask.Result.Select(x => x.PermissionId).Distinct().ToList();
            var permissions = await _repository.GetAllAsync<Permission>(x => permissionIds.Contains(x.Id));


            var accessToken = await _tokenGenerator.GenerateAccessTokenAsync(user, roles, permissions);
            var refreshToken = _tokenGenerator.GenerateRefreshTokenAsync();

            await _redisRepository.SetAsync(
                $"refresh_token:{refreshToken}:string",
                new UserLoginInfoDto { UserId = user.Id, UserAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"] },
                TimeSpan.FromDays(7));

            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
        }

        protected abstract Task<User?> GetUserAsync(TRequest request);

        protected abstract Exception GetUserOrPasswordNotFoundException();
    }
}
