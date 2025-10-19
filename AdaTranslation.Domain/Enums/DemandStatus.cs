namespace AdaTranslation.Domain.Enums
{
    /// <summary>
    /// The status of a demand
    /// </summary>
    public enum DemandStatus
    {
        Pending = 0, // just created
        Rejected = 1,
        InProgress = 2, // viewed but in process
        Completed = 3,
        Cancelled = 4
    }
}
