namespace AdaTranslation.Domain.Entities
{
    public class Language
    {
        public int Id { get; private set; }

        public required string Description { get; set; }
        public ICollection<UserLanguage> UserLanguages { get; private set; } = new HashSet<UserLanguage>();
    }
}
