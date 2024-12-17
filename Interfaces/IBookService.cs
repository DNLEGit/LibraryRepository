using LibraryApplication.Models;

namespace LibraryApplication.Interfaces
{
    public interface IBookService
    {
        void DeleteBook(int isbn);
        BookModel GetBookByIsbn(int isbn);
        IEnumerable<BookModel> GetBooks();
        void InsertBook(BookModel book);
        void ModifyLibro(int isbn, BookModel book);
    }
}