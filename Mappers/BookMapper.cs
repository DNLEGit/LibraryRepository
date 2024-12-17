using LibraryApplication.Dtos.BookDtos;
using LibraryApplication.Models;
using System.Runtime.CompilerServices;

namespace LibraryApplication.Mappers
{
    public static class BookMapper
    {

        public static BookDto BookToBookDto(this BookModel bookModel)
        {
            return new BookDto(bookModel.ISBN, bookModel.Title, bookModel.Author, bookModel.Quantity);
        }

        public static BookModel DtoToBookModel(this BookDto bookDto) 
        {

            return new BookModel(bookDto.ISBN ,bookDto.Title, bookDto.Author, bookDto.Quantity);
        
        }

        public static BookModel PutBookDtoToBookModel(this PutBookDto putBookDto, int isbn)
        {

            return new BookModel(isbn, putBookDto.Title, putBookDto.Author, putBookDto.Quantity);
        
        }

    }
}
