using LibraryApplication.Dtos.UserDtos;
using LibraryApplication.Interfaces;
using LibraryApplication.Mappers;
using LibraryApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] // Define el enrutamiento base del controlador

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController (IUserService userService)
        {
            _userService = userService;
        }




        // POST: UserController/Create
        [HttpPost]
        public IActionResult Create([FromBody] UserDto userDto)
        {
            try
            {
                _userService.CreateUser(userDto.UserDtoToUserModel());
                return Ok(userDto);
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        //Delete: USerController/Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            try
            {

                _userService.DeleteUser(id);
                return Ok();

            }
            catch (Exception ex) 
            {

                return NotFound(new { error = ex.Message });
            
            }
        
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id) 
        {
            try
            {
                                
                return Ok(_userService.GetUserById(id));

            }
            catch (Exception ex) 
            {
            
                return NotFound(new { error = ex.Message});

            }
        
        }


        [HttpGet]
        public IActionResult GetUsers() 
        {
            try
            {
                var users = _userService.GetUsers()
                    .Select(s => s.UserToGetUserDto());
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

        }

        [HttpPut]
        public IActionResult PutUser(PutUserDto user) 
        {
            try
            {

                _userService.UpdateUser(user.PutUserDtoToUserModel());
                return Ok(_userService.GetUserById(user.Id));

            }
            catch (Exception ex) 
            {

                return BadRequest(new { error = ex.Message});
            
            }
        }

        
    }
}
