using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Users.Dtos;

using MediatR;

namespace AdaTranslation.Application.Users.Queries.GetUsers
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, IEnumerable<UserDto>>
    {
        private readonly IUserQueryService _userQueryService;
        public UserGetAllQueryHandler(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }
        public async Task<IEnumerable<UserDto>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _userQueryService.GetAllAsync(cancellationToken);
        }
    }
}
