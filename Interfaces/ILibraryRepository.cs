using LibraryApplication.Models;

public interface ILibraryRepository
{
    //----------------------------------------------------------------------------------------------------------------------------------------
    
    void DeleteBook(int isbn);
    IEnumerable<BookModel> GetAllBooks();
    BookModel GetBookByISBN(int isbn);
    void InsertBook(BookModel libro);
    void UpdateBook(BookModel libro);

    //----------------------------------------------------------------------------------------------------------------------------------------

    public void InsertUser(UserModel user);
    public void DeleteUser(int id);
    public UserModel GetUserById(int id);
    public IEnumerable<UserModel> GetUsers();
    public void UpdateUser(UserModel user);

    //----------------------------------------------------------------------------------------------------------------------------------------

    public bool BorrowBook(int userId, int bookIsbn);

    public bool ReturnBook(int userId, int bookIsbn);

    public IEnumerable<BookModel> GetUserBorrowedBooks(int userId);

    //----------------------------------------------------------------------------------------------------------------------------------------
}