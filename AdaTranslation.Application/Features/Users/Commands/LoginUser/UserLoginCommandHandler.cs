using AdaTranslation.Application.Common;
using AdaTranslation.Application.Common.Interfaces;

using MediatR;

namespace AdaTranslation.Application.Features.Users.Commands.LoginUser
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, AuthResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public UserLoginCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<AuthResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.AuthenticateAsync(request.Email, request.Password, cancellationToken);
            return response;
        }
    }
}
