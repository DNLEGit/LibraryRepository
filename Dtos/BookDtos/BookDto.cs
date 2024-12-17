using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.Dtos.BookDtos
{
    public class BookDto
    {
        [Required]
        public int ISBN { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;

        [Required]
        public int Quantity { get; set; }


        public BookDto(int isbn, string title, string author, int quantity)
        {

            ISBN = isbn;
            Title = title;
            Author = author;
            Quantity = quantity;

        }

    }
}
