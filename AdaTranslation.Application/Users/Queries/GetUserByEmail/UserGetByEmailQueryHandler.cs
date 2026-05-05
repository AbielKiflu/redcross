using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Users.Dtos;

using MediatR;

namespace AdaTranslation.Application.Users.Queries.GetUserByEmail
{
    public class UserGetByEmailQueryHandler : IRequestHandler<UserGetByEmailQuery, UserDto?>
    {
        private readonly IUserRepository _userRepository;
        public UserGetByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto?> Handle(UserGetByEmailQuery request, CancellationToken cancellationToken)
        {
            var user =  await _userRepository.GetUserByEmailAsync(request.email,cancellationToken);
            return user;
        }
    }
}
