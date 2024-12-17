using LibraryApplication.Interfaces;
using LibraryApplication.Models;

namespace LibraryApplication.Services
{
    public class UserService : IUserService
    {

        private readonly ILibraryRepository _repository;

        public UserService(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public void CreateUser(UserModel user) { _repository.InsertUser(user); }

        public void DeleteUser(int id) { _repository.DeleteUser(id); }

        public UserModel GetUserById(int id)
        {

            return _repository.GetUserById(id);

        }

        public IEnumerable<UserModel> GetUsers()
        {

            return (_repository.GetUsers());
        
        }

        public void UpdateUser(UserModel user) 
        {
        
            _repository.UpdateUser(user);
        
        }
    }
}
