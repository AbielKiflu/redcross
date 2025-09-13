using AdaTranslation.Application.DTOs;
using MediatR;

namespace AdaTranslation.Application.Queries.User
{
    public record UserGetByEmailQuery(string email) :IRequest<UserDto>;
}
