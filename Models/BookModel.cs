using System.ComponentModel.DataAnnotations;


namespace LibraryApplication.Models
{
    public class BookModel
    {
        [Key]
        public int ISBN { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;

        public bool Available { get; set; }

        [Required]
        public int Quantity { get; set; }

       
        public BookModel(int isbn, string title, string author, int quantity)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Quantity = quantity;
            Available = true;

        }
        public BookModel()
        {
        }
    }

}

