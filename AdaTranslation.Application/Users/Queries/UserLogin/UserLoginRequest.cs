using AdaTranslation.Application.Users.Dtos;
using MediatR;

namespace AdaTranslation.Application.Users.Queries.UserLogin
{
    public record UserLoginRequest(string email,string password) : IRequest<UserDto>;
}
