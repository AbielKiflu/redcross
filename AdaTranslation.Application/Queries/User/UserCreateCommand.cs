using AdaTranslation.Application.DTOs;
using MediatR;

namespace AdaTranslation.Application.Queries.User
{
    public record UserCreateCommand(UserCreateDto  newUser):IRequest;
}
