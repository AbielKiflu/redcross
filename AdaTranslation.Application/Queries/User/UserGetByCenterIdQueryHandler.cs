using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries.User
{
    public class UserGetByCenterIdAndUserRoleQueryHandler : IRequestHandler<UserGetByCenterIdAndUserRoleQuery, IEnumerable<UserDto>>
    {
        private readonly IUserQueryService _userQueryService;
        public UserGetByCenterIdAndUserRoleQueryHandler(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }
        public async Task<IEnumerable<UserDto>> Handle(UserGetByCenterIdAndUserRoleQuery request, CancellationToken cancellationToken)
        {
            return await _userQueryService.GetByCenterIdAndUserRoleAsync(request.centerId, request.role,cancellationToken);
        }
    }
}
