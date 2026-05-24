namespace AdaTranslation.Domain.Entities
{
    public class DemandDetail
    {
        public int Id { get; private set; }
        public int DemandId { get; private set; }
        public int ServiceId { get; private set; }
        public string ResponsiblePersonEmail { get; private set; } = string.Empty;
        public string Message { get; private set; } = string.Empty;
        public int Duration { get; private set; }
        public long CreatedById { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public Demand Demand { get; private set; } = null!;
        public Service Service { get; private set; } = null!;

        private DemandDetail() { }

        public DemandDetail(int serviceId, string email, string message, int duration, long createdById)
        {
            if (serviceId <= 0)
                throw new ArgumentException("Valid ServiceId is required.", nameof(serviceId));

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("A valid email is required.", nameof(email));

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty.", nameof(message));

            if (duration < 0)
                throw new ArgumentOutOfRangeException(nameof(duration), "Duration cannot be negative.");

            ServiceId = serviceId;
            ResponsiblePersonEmail = email;
            Message = message;
            Duration = duration;
            CreatedById = createdById;
            CreatedDate = DateTime.UtcNow;
        }
    }
}
