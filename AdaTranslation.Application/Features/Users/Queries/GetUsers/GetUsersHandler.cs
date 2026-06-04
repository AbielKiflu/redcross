using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Features.Users.Dtos;
using AdaTranslation.Domain;
using MediatR;

namespace AdaTranslation.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, PagedResult<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PagedResult<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsersAsync(request.page, cancellationToken);
        }
    }
}
