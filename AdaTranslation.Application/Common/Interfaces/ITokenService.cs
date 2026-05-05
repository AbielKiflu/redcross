using AdaTranslation.Domain.Entities;

namespace AdaTranslation.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
