namespace AdaTranslation.Domain.Entities
{
    public class Language
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public ICollection<UserLanguage> UserLanguages { get; private set; } = [];
    }
}
