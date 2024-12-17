namespace LibraryApplication.Dtos.UserDtos
{
    public class GetUserDto
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;
        public int MaxBooks { get; set; }

        public GetUserDto(int id, string name, string type, int maxBooks) 
        {

            Id = id;
            Name = name;
            Type = type;
            MaxBooks = maxBooks;
        
        }

    }
}
