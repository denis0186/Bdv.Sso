using Bdv.Sso.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bdv.Sso.WebApi
{
    public static class Dependencies
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddMediatR(typeof(IMediatorQuery));
        }
    }
}
