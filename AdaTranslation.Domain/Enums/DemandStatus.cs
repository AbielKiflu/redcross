namespace AdaTranslation.Domain.Enums
{
    /// <summary>
    /// The status of a demand
    /// </summary>
    public enum DemandStatus
    {
        Pending = 0, // just created
        Approved = 1,
        Rejected = 2,
        InProgress = 3, // viewed but in process
        Completed = 4,
        Cancelled = 5
    }
}
