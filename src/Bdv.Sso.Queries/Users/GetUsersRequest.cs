using Bdv.Domain.Dto.Sso;
using MediatR;

namespace Bdv.Sso.Queries.Users
{
    public class GetUsersRequest : IRequest<IEnumerable<UserDto>>
    {
        public string? Search { get; set; }
    }
}
