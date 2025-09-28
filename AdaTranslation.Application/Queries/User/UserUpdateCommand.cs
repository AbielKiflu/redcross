using AdaTranslation.Application.DTOs;
using MediatR;

namespace AdaTranslation.Application.Queries.User
{
    public record UserUpdateCommand(UserUpdateDto  updateUser):IRequest;
}
