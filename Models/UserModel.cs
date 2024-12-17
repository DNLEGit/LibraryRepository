using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; }

        public int MaxBooks { get; set; }

        public UserModel() { }

        public UserModel(string type, string name, int maxBooks)
        {
            Type = type;
            Name = name;
            MaxBooks = maxBooks;
        }
        public UserModel(int id, string type, string name, int maxBooks)
        {
            Id = id;
            Type = type;
            Name = name;
            MaxBooks = maxBooks;
        }
    }
}