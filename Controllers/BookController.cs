using LibraryApplication.Dtos.BookDtos;
using LibraryApplication.Interfaces;
using LibraryApplication.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    public class BookController : ControllerBase 
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // POST: api/Book
        [HttpPost]
        public IActionResult Post([FromBody] BookDto bookDto)
        {
            try
            {
                var bookModel = bookDto.DtoToBookModel();
                _bookService.InsertBook(bookModel);
                return Ok(bookModel.BookToBookDto());
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpDelete("{isbn}")]
        public IActionResult Delet(int isbn) 
        {
            try
            {
                
                _bookService.DeleteBook(isbn);
                return Ok();

            }
            catch (Exception ex) 
            {

                return NotFound(new { error = ex.Message });


            }
        
        }

        [HttpGet("{isbn}")]
        public IActionResult Get(int isbn)
        {
            try
            {
                
                var book = _bookService.GetBookByIsbn(isbn);
                return Ok(book.BookToBookDto());

            }

            catch (Exception ex) 
            {

                return NotFound(new { error = ex.Message });

            }
        
        }

        [HttpGet]
        public IActionResult Get() 
        {

            try
            {
                var libros = _bookService.GetBooks()
                    .Select(s => s.BookToBookDto());
                return Ok(libros);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

        }

        [HttpPut("{isbn}")]
        public IActionResult Put(int isbn, PutBookDto book) 
        {
            try
            {

                _bookService.ModifyLibro(isbn, book.PutBookDtoToBookModel(isbn));
                return Ok();

            }
            catch (Exception ex) 
            {

                return NotFound(new { error = ex.Message });
                
            }
        }
    }
}
