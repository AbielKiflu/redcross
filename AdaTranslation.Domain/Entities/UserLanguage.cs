namespace AdaTranslation.Domain.Entities
{
    public class UserLanguage
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int LanguageId { get; private set; }

        public User User { get; private set; } = null!;
        public Language Language { get; private set; } = null!;

        private UserLanguage() { }   

        public UserLanguage(int userId, int languageId)
        {
            UserId = userId;
            LanguageId = languageId;
        }
    }
}