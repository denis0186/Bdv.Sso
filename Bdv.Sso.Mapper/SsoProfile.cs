using AutoMapper;
using Bdv.Domain.Dto.Sso;
using Bdv.Sso.Domain.Entities;

namespace Bdv.Sso.Mapper
{
    public class SsoProfile : Profile
    {
        public SsoProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
