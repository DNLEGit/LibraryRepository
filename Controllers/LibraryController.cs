using LibraryApplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {

        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService service)
        {
        
            _libraryService = service;

        }
      
        // POST: HomeController/Create
        [HttpPost]
        public IActionResult Create(int id, int isbn)
        {
            try
            {
                _libraryService.BorrowBook(id, isbn);
                return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(new { error = ex.Message});
            }
        }

        //Delete
        [HttpDelete]
        public IActionResult Delete(int id, int isbn)
        {
            try
            {

                _libraryService.ReturnBook(id, isbn);
                return Ok("Libro devuelto con exito");

            }
            catch (Exception ex) 
            {

                return BadRequest(new { error = ex.Message });
            
            }
        
        }
        [HttpGet]
        public IActionResult Get(int id) 
        {
            try
            {

                return Ok(_libraryService.GetUserBorrowedBooks(id));


            }
            catch (Exception ex) 
            {
            
                return NotFound(new { error = ex.Message });
            
            }
        
        }
    }
}
