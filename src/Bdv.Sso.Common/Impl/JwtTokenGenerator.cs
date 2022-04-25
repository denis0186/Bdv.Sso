using Bdv.Sso.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdv.Sso.Common.Impl
{
    public class JwtTokenGenerator : ITokenGenerator
    {
        public Task<string> GenerateAccessTokenAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateRefreshTokenAsync(User user, string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
