
using System.Text.Json.Serialization;

namespace AdaTranslation.Domain.Entities
{
    public class Center
    {
        public int ID { get; set; }
        public required string Description { get; set; }
        public required string Address { get; set; }
        public required string Contact { get; set; }
        public ICollection<User> Users { get; } = [];
        public ICollection<Demand> Demands { get; } = [];

        //private Center() {  }
        
    }
}
