using AdaTranslation.Application.Users.Dtos;
using MediatR;

namespace AdaTranslation.Application.Users.Commands.CreateUser
{
    public record UserCreateCommand(UserCreateDto  user):IRequest<long>;
}
