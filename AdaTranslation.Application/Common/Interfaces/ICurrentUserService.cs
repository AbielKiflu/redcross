using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        long? UserId { get; }
        UserRole? Role { get; }
        int? CenterId { get; }
        bool IsAuthenticated { get; }
    }
}
