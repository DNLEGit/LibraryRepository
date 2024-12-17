namespace LibraryApplication.Dtos.UserDtos
{
    public class UserDto
    {
               
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public UserDto(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}
