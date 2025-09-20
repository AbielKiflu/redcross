namespace AdaTranslation.Application.DTOs
{
    public class CenterDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty; 
        public List<UserDto> Users { get; set; } = new();
    }
}


