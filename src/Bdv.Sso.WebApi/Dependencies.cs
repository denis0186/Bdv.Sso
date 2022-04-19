using Bdv.Sso.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Bdv.Sso.DataAccess;
using Microsoft.Extensions.Configuration;

namespace Bdv.Sso.WebApi
{
    public static class Dependencies
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            //SQRS support
            services.AddMediatR(typeof(IMediatorQuery));

            //Database context
            services.AddDbContext<SsoContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("sso-db"),
                x => x.MigrationsAssembly("Bdv.Sso.Migrations")));
        }
    }
}
