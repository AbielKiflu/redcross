using AdaTranslation.Application.Features.Users.Dtos;
using AdaTranslation.Domain;

using MediatR;

namespace AdaTranslation.Application.Features.Users.Queries.GetUsers
{
    public record GetUsersQuery(Page page) : IRequest<PagedResult<UserDto>>;
}
