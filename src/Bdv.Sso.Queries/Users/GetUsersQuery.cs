using Bdv.Domain.Dto.Sso;
using MediatR;

namespace Bdv.Sso.Queries.Users
{
    public class GetUsersQuery : IRequestHandler<GetUsersRequest, IEnumerable<UserDto>>
    {
        public Task<IEnumerable<UserDto>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            //Test
            return Task.FromResult(Enumerable.Repeat(new UserDto { Id = 1, Email = "example@com" }, 3));
        }
    }
}
