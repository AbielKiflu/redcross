namespace AdaTranslation.Domain.Entities
{
    public class Language
    {
        private string _description = string.Empty;
        public int Id { get; private set; }
        public string Description 
        {
            get => _description;
            private set => _description = value;
        }
        public ICollection<UserLanguage> UserLanguages { get; private set; } = new HashSet<UserLanguage>();

        private Language() { }

        public Language(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Language cannot be empty or null " + nameof(Description));
            _description = description;
        }

    }
}
