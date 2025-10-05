using AdaTranslation.Application.DTOs;
using MediatR;

namespace AdaTranslation.Application.Queries.User
{
    public record UserGetByIdQuery(int id) :IRequest<UserDto>;
}
