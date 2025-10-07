namespace AdaTranslation.Domain.Entities
{
    public class Center
    {
        public int Id { get; set; }

        public required string Description { get; set; }
        public required string Address { get; set; }
        public required string Contact { get; set; }

        // Use HashSet to avoid duplicates and improve EF navigation property behavior
        public ICollection<User> Users { get; } = new HashSet<User>();
        public ICollection<Demand> Demands { get; } = new HashSet<Demand>();
    }

}
