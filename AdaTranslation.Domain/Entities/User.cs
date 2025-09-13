using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Domain.Entities
{
    public class User
    {
        public int ID { get; private set; }
        public  string LastName { get; private set; }
        public  string FirstName { get; private set; }
        public  string Telephone { get; private set; }
        public  string Email { get; private set; }
        public DateTime? PauseStartDate { get; private set; }
        public DateTime? PauseFinishDate { get; private set; }
        public int CenterID { get; private set; }
        public string? GoogleId { get; private set; }

   


        public Center Center { get; private set; } = null!;
        public UserRole UserRole { get; private set; } = UserRole.Guest;
        public ICollection<UserLanguage> UserLanguages { get; private set; } = [];


        private User() { } // EF Core needs this
        public User(string firstName,string lastName, string email, string telephone)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required", nameof(lastName));

            if (string.IsNullOrWhiteSpace(telephone))
                throw new ArgumentException("Telephone is required", nameof(telephone));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Valid Email is required", nameof(email));

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;
        }

        public void SetGoogleId(string googleId)
        {
            if (string.IsNullOrWhiteSpace(googleId))
                throw new ArgumentException("Google ID cannot be empty", nameof(googleId));

            GoogleId = googleId;
        }

    }
}
