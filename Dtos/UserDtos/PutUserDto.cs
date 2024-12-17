namespace LibraryApplication.Dtos.UserDtos
{
    public class PutUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public PutUserDto(int id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
    }
}