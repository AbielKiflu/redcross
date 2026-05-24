namespace AdaTranslation.Domain.Entities
{
    public class Center
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public string Contact { get; private set; } = string.Empty;
        public ICollection<User> Users { get; } = new HashSet<User>();
        public ICollection<Demand> Demands { get; } = new HashSet<Demand>();

        private Center() { }

        public Center(string description, string address, string contact)
        {
            ValidateInputs(description, address, contact);

            Description = description;
            Address = address;
            Contact = contact;
        }

        /// <summary>
        /// Update center
        /// </summary>
        public void Update(string newDescription, string newAddress, string newContact)
        {
            ValidateInputs(newDescription, newAddress, newContact);

            Description = newDescription;
            Address = newAddress;
            Contact = newContact;
        }

        private void ValidateInputs(string description, string address, string contact)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required.", nameof(description));

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address is required.", nameof(address));

            if (string.IsNullOrWhiteSpace(contact))
                throw new ArgumentException("Contact details are required.", nameof(contact));
        }
    }
}
