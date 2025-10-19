using AdaTranslation.Application.Users.Dtos;

using MediatR;

namespace AdaTranslation.Application.Users.Commands.UpdateUser
{
    public record UserUpdateCommand(UserUpdateDto  user):IRequest;
}
