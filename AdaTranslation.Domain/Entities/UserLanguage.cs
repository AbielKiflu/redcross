namespace AdaTranslation.Domain.Entities
{
    public class UserLanguage
    {
        public int Id { get; private set; }

        public long UserId { get; private set; }
        public int LanguageId { get; private set; }
        public User User { get; private set; } = null!;
        public Language Language { get; private set; } = null!;

        private UserLanguage() { }

        public UserLanguage(long userId, int languageId)
        {
            LanguageId = languageId;
            UserId = userId;
        }

        public void Update(long userId, int languageId)
        {
            LanguageId = languageId;
            UserId = userId;
        }

    }
}
