using AdaTranslation.Application.Features.Users.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Users.Commands.CreateUser
{
    public record UserCreateCommand(UserCreateDto  user):IRequest<long>;
}
