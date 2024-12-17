using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.Dtos.BookDtos
{
    public class PutBookDto
    {

        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;

        [Required]
        public int Quantity { get; set; }

        public PutBookDto( string title, string author, int quantity)

            {

                Title = title;
                Author = author;
                Quantity = quantity;

            }

    }

    
}
