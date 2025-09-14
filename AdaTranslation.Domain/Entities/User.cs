using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Domain.Entities
{
    public class User
    {
        public long ID { get; private set; }
        public string LastName { get; private set; }
        public  string FirstName { get; private set; }
        public  string Telephone { get; private set; }
        public  string Email { get; private set; }
        public DateTime? PauseStartDate { get; private set; }
        public DateTime? PauseEndDate { get; private set; }
        public int CenterID { get; private set; }
        public string? GoogleId { get; private set; }
        public Center Center { get; private set; } = null!;
        public UserRole UserRole { get; private set; } = UserRole.Mediator;
        public ICollection<UserLanguage> UserLanguages { get; private set; } = []; 
    }
}
