using AdaTranslation.Application.Common.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Users.Commands.UpdateUser
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand>
    {
        private readonly IUserRepository _userRepository;

        public UserUpdateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
             await _userRepository.UpdateAsync(request.user, cancellationToken);
        }
    }
}
