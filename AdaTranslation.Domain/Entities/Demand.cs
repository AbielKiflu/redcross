using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Domain.Entities
{
    public class Demand
    {
        public int Id { get; private set; }
        public string Subject { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public DateTime StartDate { get; private set; }
        public DateTime FinishDate { get; private set; }

        public DemandPriority Priority { get; private set; } = DemandPriority.Low;
        public DemandStatus Status { get; private set; } = DemandStatus.Draft;
        public DemandType DemandType { get; private set; } = DemandType.Site;

        public long? DemandedUserId { get; private set; }
        public int CenterId { get; private set; }
        public long CreatedById { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public User? DemandedUser { get; private set; }
        public Center Center { get; private set; } = null!;
        public User CreatedBy { get; private set; } = null!;

        private readonly List<DemandDetail> _demandDetails = new();
        public IReadOnlyCollection<DemandDetail> DemandDetails => _demandDetails.AsReadOnly();

        private Demand() { }

        public Demand(string subject, string description, int centerId, long createdById, DemandType type = DemandType.Site)
        {
            if (string.IsNullOrWhiteSpace(subject))
                throw new ArgumentException("Subject is required.", nameof(subject));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required.", nameof(description));

            if (centerId <= 0)
                throw new ArgumentException("A valid CenterId is required.", nameof(centerId));

            Subject = subject;
            Description = description;
            CenterId = centerId;
            CreatedById = createdById;
            DemandType = type;

            Status = DemandStatus.Draft;
            CreatedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Updates the core textual and type details of the demand if it hasn't been finalized.
        /// </summary>
        public void Update(string newSubject, string newDescription, DemandType newType)
        {
            if (Status == DemandStatus.Completed || Status == DemandStatus.Cancelled)
            {
                throw new InvalidOperationException($"Cannot update a demand that is already in a '{Status}' state.");
            }

            if (string.IsNullOrWhiteSpace(newSubject))
                throw new ArgumentException("Subject cannot be empty.", nameof(newSubject));

            if (string.IsNullOrWhiteSpace(newDescription))
                throw new ArgumentException("Description cannot be empty.", nameof(newDescription));

            Subject = newSubject;
            Description = newDescription;
            DemandType = newType;
        }

        public void ScheduleDates(DateTime start, DateTime finish)
        {
            if (finish < start)
                throw new ArgumentException("Finish date cannot be earlier than start date.");

            StartDate = start;
            FinishDate = finish;
        }

        public void AssignToUser(long userId)
        {
            if (userId <= 0)
                throw new ArgumentException("Invalid user assignment.", nameof(userId));

            DemandedUserId = userId;
        }

        public void AddDetail(int serviceId, string email, string message, int duration)
        {
            if (Status == DemandStatus.Completed || Status == DemandStatus.Cancelled)
                throw new InvalidOperationException("Cannot add details to a finalized demand.");

            var detail = new DemandDetail(serviceId, email, message, duration, this.CreatedById);
            _demandDetails.Add(detail);
        }

        public void ChangePriority(DemandPriority newPriority)
        {
            Priority = newPriority;
        }

        public void SubmitForReview()
        {
            if (!_demandDetails.Any())
                throw new InvalidOperationException("A demand must have at least one Service Detail before it can be submitted.");

            Status = DemandStatus.Submitted;
        }
    }
}
