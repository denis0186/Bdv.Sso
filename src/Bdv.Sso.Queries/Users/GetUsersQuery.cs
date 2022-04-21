using AutoMapper;
using Bdv.DataAccess;
using Bdv.Domain.Dto.Sso;
using Bdv.Sso.Domain.Entities;
using MediatR;

namespace Bdv.Sso.Queries.Users
{
    public class GetUsersQuery : IRequestHandler<GetUsersRequest, IEnumerable<UserDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetUsersQuery(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<UserDto>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync<User>();
            return users.Select(x => _mapper.Map(x, new UserDto()));
        }
    }
}
