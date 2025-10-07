namespace AdaTranslation.Domain.Entities
{
    public class UserLanguage
    {
        public int Id { get; private set; }

        public long UserId { get; private set; }
        public int LanguageId { get; private set; }
        public  User User { get; set; } = null!;
        public  Language Language { get; set; } = null!;
    }
}
