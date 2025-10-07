using AdaTranslation.Application.Common.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Users.Commands.CreateUser
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand>
    {
        private readonly IUserRepository _userRepository;

        public UserCreateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
             await _userRepository.CreateAsync(request.user, cancellationToken);
        }
    }
}
