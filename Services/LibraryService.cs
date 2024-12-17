using LibraryApplication.Interfaces;
using LibraryApplication.Models;

namespace LibraryApplication.Services
{
    public class LibraryService : ILibraryService
    {

        private readonly ILibraryRepository _repository;

        public LibraryService(ILibraryRepository repository)
        {

            _repository = repository;

        }

        public void BorrowBook(int id, int isbn)
        {

            _repository.BorrowBook(id, isbn);

        }

        public void ReturnBook(int id, int isbn)
        {

            _repository.ReturnBook(id, isbn);

        }

        public IEnumerable<BookModel> GetUserBorrowedBooks(int id)
        {

            return _repository.GetUserBorrowedBooks(id);

        }

    }
}
