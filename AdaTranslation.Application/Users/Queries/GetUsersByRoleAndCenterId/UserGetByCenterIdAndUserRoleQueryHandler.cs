using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Users.Dtos;

using MediatR;

namespace AdaTranslation.Application.Users.Queries.GetUsersByRoleAndCenterId
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
