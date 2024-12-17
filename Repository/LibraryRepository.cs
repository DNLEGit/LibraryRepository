using LibraryApplication.DataBase;
using LibraryApplication.Models;
using Dapper;

public class LibraryRepository : ILibraryRepository
{
    private readonly DapperContext _context;

    public LibraryRepository(DapperContext context)
    {
        _context = context;
    }

    //-Crud Book---------------------------------------------------------------------------

    public void InsertBook(BookModel book)
{
    // Definir la consulta SQL de inserción
    var query = "INSERT INTO Books (ISBN, Title, Author, Quantity) VALUES (@ISBN, @Title, @Author, @Quantity)";

    // Usar Dapper para ejecutar la consulta
    using (var connection = _context.CreateConnection())
    {
        connection.Execute(query, new
        {
            ISBN = book.ISBN,       // Coincide con @ISBN
            Title = book.Title,     // Coincide con @Title
            Author = book.Author,   // Coincide con @Author
            Quantity = book.Quantity // Coincide con @Quantity
        });
    }
}

    public void DeleteBook(int isbn)
    {

        var query = "DELETE FROM Books WHERE ISBN = @ISBN";

        using (var connection = _context.CreateConnection())
        {

            connection.Execute(query, new { ISBN = isbn });

        }

    }

    public IEnumerable<BookModel> GetAllBooks()
    {

        var query = "SELECT ISBN, Title, Author, Available, Quantity FROM Books";


        using (var connection = _context.CreateConnection())
        {
            return connection.Query<BookModel>(query).ToList();
        }
    }

    public BookModel GetBookByISBN(int isbn)
    {
      
        var query = "SELECT ISBN, Title, Author, Available, Quantity FROM Books WHERE ISBN = @ISBN";

    
        using (var connection = _context.CreateConnection())
        {
            return connection.QuerySingleOrDefault<BookModel>(query, new { ISBN = isbn });
        }
    }

    public void UpdateBook(BookModel book)
    {
       
        var query = @"
        UPDATE Books
        SET Title = @Title, 
            Author = @Author, 
            Available = @Available, 
            Quantity = @Quantity
        WHERE ISBN = @ISBN";

        using (var connection = _context.CreateConnection())
        {
            
            connection.Execute(query, new
            {
                Title = book.Title,
                Author = book.Author,
                Available = book.Available,
                Quantity = book.Quantity,
                ISBN = book.ISBN 
            });
        }
    }


    //-Crud User---------------------------------------------------------------------------

    public void InsertUser(UserModel user)
    {

        // Definir la consulta SQL de inserción
        var query = "INSERT INTO Users (Name ,Type ,MaxBooks) VALUES (@Name, @Type, @MaxBooks)";

        // Usar Dapper para ejecutar la consulta
        using (var connection = _context.CreateConnection())
        {
            connection.Execute(query, new
            {
                Name = user.Name,
                Type = user.Type,
                MaxBooks = user.MaxBooks,

            });
        }

    }


    public void DeleteUser(int id)
    {

        var query = "DELETE FROM Users WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {

            connection.Execute(query, new { Id = id });

        }

    }

    public IEnumerable<UserModel> GetUsers()
    {

        var query = "SELECT Id, Name, Type, MaxBooks FROM Users";


        using (var connection = _context.CreateConnection())
        {
            return connection.Query<UserModel>(query).ToList();
        }
    }

    public UserModel GetUserById(int id)
    {
        // La consulta SELECT para obtener un libro por su ISBN
        var query = "SELECT Id, Name, Type, MaxBooks FROM Users WHERE Id = @Id";

        // Ejecutar la consulta utilizando Dapper
        using (var connection = _context.CreateConnection())
        {
            return connection.QuerySingleOrDefault<UserModel>(query, new { Id = id });
        }
    }

    public void UpdateUser(UserModel user)
    {

        var query = @"
        UPDATE Users
        SET Name = @Name, 
            Type = @Type,
            MaxBooks = @MaxBooks
        WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {

            connection.Execute(query, new
            {
                Name = user.Name,
                Type = user.Type,
                MaxBooks = user.MaxBooks,
                Id = user.Id

            });
        }
    }

    //-Crud Library---------------------------------------------------------------------------

    public bool BorrowBook(int userId, int bookIsbn)
    {
        using (var connection = _context.CreateConnection())
        {
            // Verificar las condiciones
            var sqlCheck = @"
            SELECT 
                b.Quantity, 
                (SELECT COUNT(*) FROM Library WHERE UserId = @UserId) AS BorrowedBooks, 
                u.MaxBooks
            FROM Books b
            INNER JOIN Users u ON u.Id = @UserId
            WHERE b.ISBN = @BookIsbn";

            var result = connection.QueryFirstOrDefault(sqlCheck, new { UserId = userId, BookIsbn = bookIsbn });

            if (result == null)
                throw new Exception("Book or User not found.");

            if (result.Quantity <= 0)
                throw new Exception("No copies of the book are available.");

            if (result.BorrowedBooks >= result.MaxBooks)
                throw new Exception("User has reached the maximum number of borrowed books.");

            // Insertar en la tabla Library
            var sqlInsert = @"
            INSERT INTO Library (UserId, BookIsbn, Title)
            SELECT @UserId, @BookIsbn, b.Title
            FROM Books b
            WHERE b.ISBN = @BookIsbn";

            connection.Execute(sqlInsert, new { UserId = userId, BookIsbn = bookIsbn });

            // Actualizar la cantidad de libros disponibles
            var sqlUpdate = @"
            UPDATE Books
            SET Quantity = Quantity - 1
            WHERE ISBN = @BookIsbn";

            connection.Execute(sqlUpdate, new { BookIsbn = bookIsbn });

            return true;
        }
    }


    public bool ReturnBook(int userId, int bookIsbn)
    {
        using (var connection = _context.CreateConnection())
        {
            // Verificar que el préstamo exista
            var sqlCheck = @"
            SELECT COUNT(*) 
            FROM Library 
            WHERE UserId = @UserId AND BookIsbn = @BookIsbn";

            var exists = connection.ExecuteScalar<int>(sqlCheck, new { UserId = userId, BookIsbn = bookIsbn });

            if (exists == 0)
                throw new Exception("This book was not borrowed by the user.");

            // Eliminar el préstamo de la tabla Library
            var sqlDelete = @"
            DELETE FROM Library
            WHERE UserId = @UserId AND BookIsbn = @BookIsbn";

            connection.Execute(sqlDelete, new { UserId = userId, BookIsbn = bookIsbn });

            // Incrementar la cantidad de libros disponibles
            var sqlUpdate = @"
            UPDATE Books
            SET Quantity = Quantity + 1
            WHERE ISBN = @BookIsbn";

            connection.Execute(sqlUpdate, new { BookIsbn = bookIsbn });

            return true;
        }
    }


    public IEnumerable<BookModel> GetUserBorrowedBooks(int userId)
    {
        using (var connection = _context.CreateConnection())
        {
            var sql = @"
            SELECT 
                b.ISBN,
                b.Title,
                b.Author,
                b.Quantity,
                CASE WHEN b.Quantity > 0 THEN 1 ELSE 0 END AS Available
            FROM Library l
            INNER JOIN Books b ON l.BookIsbn = b.ISBN
            WHERE l.UserId = @UserId";

            return connection.Query<BookModel>(sql, new { UserId = userId });
        }
    }


}
