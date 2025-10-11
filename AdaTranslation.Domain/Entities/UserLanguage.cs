namespace AdaTranslation.Domain.Entities
{
    public class UserLanguage
    {
        public int Id { get; set; }

        public long UserId { get; set; }
        public int LanguageId { get; set; }
        public  User User { get; set; } = null!;
        public  Language Language { get; set; } = null!;
    }
}
