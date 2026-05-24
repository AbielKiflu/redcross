using AdaTranslation.Application.Common.Interfaces;

using MediatR;

namespace AdaTranslation.Application.Features.Users.Commands.CreateUser
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, long>
    {
        private readonly IUserRepository _userRepository;

        public UserCreateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<long> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
             var createdId = await _userRepository.CreateAsync(request.user, cancellationToken);
            return createdId;
        }
    }
}
