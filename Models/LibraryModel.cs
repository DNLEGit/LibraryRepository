namespace LibraryApplication.Models
{
    public class LibraryModel
    {

        public int id { get; set; }

        public int UserId { get; set; }

        public int BookIsbn { get; set; }

        public string Title { get; set; } = string.Empty;

        public LibraryModel(int userId, int bookIsbn, string title) 
        {
            
            UserId = userId;
            BookIsbn = bookIsbn;
            Title = title;
        
        }

    }
}
