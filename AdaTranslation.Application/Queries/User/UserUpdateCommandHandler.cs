using AdaTranslation.Domain.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries.User
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
             await _userRepository.UpdateAsync(request, cancellationToken);
        }
    }
}
