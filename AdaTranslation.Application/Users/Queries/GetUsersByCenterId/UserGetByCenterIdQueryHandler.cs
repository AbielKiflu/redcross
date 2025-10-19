using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Users.Dtos;

using MediatR;

namespace AdaTranslation.Application.Users.Queries.GetUsersByCenterId
{
    public class UserGetByCenterIdQueryHandler : IRequestHandler<UserGetByCenterIdQuery, IEnumerable<UserDto>>
    {
        private readonly IUserQueryService _userQueryService;
        public UserGetByCenterIdQueryHandler(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }
        public async Task<IEnumerable<UserDto>> Handle(UserGetByCenterIdQuery request, CancellationToken cancellationToken)
        {
            return await _userQueryService.GetByCenterIdAsync(request.centerId,cancellationToken);
        }
    }
}
