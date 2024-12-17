using LibraryApplication.Models;

namespace LibraryApplication.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserModel user);
        public void DeleteUser(int id);

        public UserModel GetUserById(int id);
        public IEnumerable<UserModel> GetUsers();

        public void UpdateUser(UserModel user);
    }
}