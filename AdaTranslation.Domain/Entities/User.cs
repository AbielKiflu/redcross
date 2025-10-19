using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }

        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public required string Telephone { get; set; }
        public required string Email { get; set; }

        public DateTime? PauseStartDate { get; set; }
        public DateTime? PauseEndDate { get; set; }

        public int CenterId { get; set; }
        public string? GoogleId { get; set; }

        public Center Center { get; set; } = null!;
        public UserRole UserRole { get; set; } = UserRole.Mediator;

        // Initialize collection using HashSet to avoid duplicates
        public ICollection<UserLanguage> UserLanguages { get; } = new HashSet<UserLanguage>();
    }
}
