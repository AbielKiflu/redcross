using AdaTranslation.Application.Common;

using MediatR;

namespace AdaTranslation.Application.Features.Users.Commands.LoginUser
{
    public record UserLoginCommand
    (
    string Email,
    string Password
    ) : IRequest<AuthResponse>;
}
