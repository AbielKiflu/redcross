using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Users.Dtos;
using MediatR;

namespace AdaTranslation.Application.Users.Queries.UserLogin
{
    public class UserLoginRequestHandler(IUserRepository userRepository) : IRequestHandler<UserLoginRequest, UserDto>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserDto> Handle(UserLoginRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByLogin(request.email, cancellationToken);
        }
    }
}
