namespace AdaTranslation.Domain.Entities
{
    public class Service
    {
        private readonly List<DemandDetail> _demandDetails = new();
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public IReadOnlyCollection<DemandDetail> DemandDetails => _demandDetails.AsReadOnly();

        private Service() { }

        public Service(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));

            Description = description;
        }

        public Service(int id, string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));

            Description = description;
            Id = id;
        }

        public void AddDemandDetail(DemandDetail demandDetail)
        {
            _demandDetails.Add(demandDetail);
        }

    }
}
