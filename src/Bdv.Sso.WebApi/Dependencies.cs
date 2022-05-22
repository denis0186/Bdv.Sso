using Bdv.Sso.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Bdv.Sso.DataAccess;
using Microsoft.Extensions.Configuration;
using Bdv.DataAccess;
using Bdv.DataAccess.Impl.EntityFramework;
using Bdv.Sso.Mapper;
using Bdv.Sso.Common;
using Bdv.Sso.Common.Impl;
using Bdv.Sso.Commands;
using Bdv.Authentication;

namespace Bdv.Sso.WebApi
{
    public static class Dependencies
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            //SQRS support
            services.AddMediatR(typeof(IMediatorQuery), typeof(IMediatorCommand));

            //Database context
            services.AddDbContext<SsoContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("sso-db"),
                x => x.MigrationsAssembly("Bdv.Sso.Migrations")));

            //Data access
            services
                .AddTransient<IRepository, DbContextRepository<SsoContext>>()
                .AddTransient<ICrudService, DbContextCrudService<SsoContext>>();

            //Mapper
            services.AddAutoMapper(typeof(SsoProfile));

            //Settings
            var appSettings = new AppSettings(configuration);
            services
                .AddSingleton<ITokenGeneratorSettings>(appSettings)
                .AddSingleton<ITokenValidationSettings>(appSettings);

            //Services
            services
                .AddSingleton<ITokenGenerator, TokenGenerator>()
                .AddSingleton<IPasswordHasher, Md5PasswordHasher>();
        }
    }
}
