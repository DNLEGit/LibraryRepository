using LibraryApplication.Models;

namespace LibraryApplication.Interfaces
{
    public interface ILibraryService
    {
        void BorrowBook(int id, int isbn);
        IEnumerable<BookModel> GetUserBorrowedBooks(int id);
        void ReturnBook(int id, int isbn);
    }
}