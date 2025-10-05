using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries.User
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
