namespace AdaTranslation.Application.DTOs
{
    public class UserDto
    {
        public long ID { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
