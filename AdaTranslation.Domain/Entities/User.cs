using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Domain.Entities
{
    public class User
    {
        // EF Core can read/write to private setters using backing fields or reflection
        public long Id { get; private set; }
        public string LastName { get; private set; } = string.Empty;
        public string FirstName { get; private set; } = string.Empty;
        public string Telephone { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public DateTime? PauseStartDate { get; private set; }
        public DateTime? PauseEndDate { get; private set; }
        public int CenterId { get; private set; }
        public string? GoogleId { get; private set; }

        // Navigation Property for EF Core (kept inside domain or mapped via Data Layer)
        public Center Center { get; private set; } = null!;
        public UserRole UserRole { get; private set; } = UserRole.Mediator;

        // Encapsulated Collection to protect business invariants
        private readonly HashSet<UserLanguage> _userLanguages = new();
        public virtual IReadOnlyCollection<UserLanguage> UserLanguages => _userLanguages;

        // EF Core requires a parameterless constructor
        private User() { }

        public User(string firstName, string lastName, string email, string telephone, int centerId, UserRole role)
        { 
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;
            CenterId = centerId;
            UserRole = role;
        }

 
        /// <summary>
        /// Update user
        /// </summary>
        public void UpdateDetails(string firstName, string lastName, string telephone, int centerId, UserRole role)
        {
            FirstName = firstName;
            LastName = lastName;
            Telephone = telephone;
            CenterId = centerId;
            UserRole = role;
        }

        /// <summary>
        /// Evaluates whether the user is currently on pause/vacation on a given date.
        /// </summary>
        public bool IsAvailableOn(DateTime date)
        {
            if (PauseStartDate.HasValue && PauseEndDate.HasValue)
            {
                // Returns false if the requested date falls strictly within the pause window
                return date < PauseStartDate.Value || date > PauseEndDate.Value;
            }
            return true;
        }

        /// <summary>
        /// Business rule to safely set a new pause period.
        /// </summary>
        public void UpdatePausePeriod(DateTime? start, DateTime? end)
        {
            if (start.HasValue && end.HasValue && end.Value < start.Value)
            {
                throw new InvalidOperationException("The pause end date cannot be earlier than the start date.");
            }

            PauseStartDate = start;
            PauseEndDate = end;
        }

        /// <summary>
        /// Business rule checking whether this user supports a specific target language.
        /// </summary>
        public bool SpeaksLanguage(long languageId)
        {
            return _userLanguages.Any(ul => ul.LanguageId == languageId);
        }


    }
}
