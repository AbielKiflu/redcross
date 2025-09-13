using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries.User
{
    public class UserGetByEmailQueryHandler : IRequestHandler<UserGetByEmailQuery, UserDto>
    {
        private readonly IUserQueryService _userQueryService;
        public UserGetByEmailQueryHandler(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }
        public async Task<UserDto> Handle(UserGetByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _userQueryService.GetUserByEmailAsync(request.email,cancellationToken);
        }
    }
}
