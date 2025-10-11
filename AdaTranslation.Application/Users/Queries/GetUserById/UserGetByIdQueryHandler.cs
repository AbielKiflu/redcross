using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Users.Dtos;
using MediatR;

namespace AdaTranslation.Application.Users.Queries.GetUserById
{
    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery, UserDto>
    {
        private readonly IUserQueryService _userQueryService;
        public UserGetByIdQueryHandler(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }
        public async Task<UserDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userQueryService.GetUserByIdAsync(request.id,cancellationToken);
        }
    }
}
