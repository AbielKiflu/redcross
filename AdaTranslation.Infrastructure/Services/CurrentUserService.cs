using System.Security.Claims;

using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Domain.Enums;

using Microsoft.AspNetCore.Http;

namespace AdaTranslation.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public long? UserId
        {
            get
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?
                    .FindFirst(ClaimTypes.NameIdentifier)?.Value;

                return long.TryParse(userIdClaim, out var id) ? id : null;
            }
        }

        public UserRole? Role
        {
            get
            {
                var roleClaim = _httpContextAccessor.HttpContext?.User?
                    .FindFirst(ClaimTypes.Role)?.Value;

                return Enum.TryParse<UserRole>(roleClaim, true, out var role) ? role : null;
            }
        }

        public int? CenterId
        {
            get
            {
                var centerClaim = _httpContextAccessor.HttpContext?.User?
                    .FindFirst("CenterId")?.Value;

                return int.TryParse(centerClaim, out var centerId) ? centerId : null;
            }
        }

        public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
