using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Users.Dtos;

using MediatR;

namespace AdaTranslation.Application.Users.Queries.GetUsersByRole
{
    public class UserGetByUserRoleQueryHandler : IRequestHandler<UserGetByUserRoleQuery, IEnumerable<UserDto>>
    {
        private readonly IUserQueryService _userQueryService;
        public UserGetByUserRoleQueryHandler(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }
        public async Task<IEnumerable<UserDto>> Handle(UserGetByUserRoleQuery request, CancellationToken cancellationToken)
        {
            return await _userQueryService.GetByUserRoleIdAsync(request.role,cancellationToken);
        }
    }
}
