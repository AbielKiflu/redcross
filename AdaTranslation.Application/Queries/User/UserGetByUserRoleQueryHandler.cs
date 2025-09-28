using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries.User
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
