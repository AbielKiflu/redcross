using AdaTranslation.Application.Features.Users.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Users.Commands.UpdateUser
{
    public record UserUpdateCommand(UserUpdateDto user) : IRequest;
}
