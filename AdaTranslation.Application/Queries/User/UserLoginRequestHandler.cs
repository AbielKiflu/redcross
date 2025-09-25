using AdaTranslation.Application.DTOs;
using AdaTranslation.Domain.Interfaces;

using MediatR;

namespace AdaTranslation.Application.Queries.User
{
    public class UserLoginRequestHandler(IUserRepository userRepository) : IRequestHandler<UserLoginRequest, UserDto>
    {
        private readonly IUserRepository _userRepository = userRepository;
        public async Task<UserDto> Handle(UserLoginRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByLogin(request, cancellationToken);
        }
    }
}
