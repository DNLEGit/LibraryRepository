
using LibraryApplication.Interfaces;
using LibraryApplication.Models;

namespace LibraryApplication.Services
{
    public class BookService : IBookService
    {

        private readonly ILibraryRepository _repository;

        public BookService(ILibraryRepository repository) { _repository = repository; }

        public void InsertBook(BookModel book)
        {

            _repository.InsertBook(book);

        }

        public void DeleteBook(int isbn) { _repository.DeleteBook(isbn); }

        public BookModel GetBookByIsbn(int isbn) { return _repository.GetBookByISBN(isbn); }


        public IEnumerable<BookModel> GetBooks() { return _repository.GetAllBooks(); }


        public void ModifyLibro(int isbn, BookModel book)
        {

            _repository.UpdateBook(book);


        }


    }
}
