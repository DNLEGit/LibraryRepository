using LibraryApplication.Models;
using LibraryApplication.Dtos.UserDtos;
using LibraryApplication.Dtos.BookDtos;

namespace LibraryApplication.Mappers
{
    public static class UserMapper
    {
        public static UserDto UserToUserDto(this UserModel user) 
        {

            return new UserDto(user.Name, user.Type);
        
        }
                
        public static GetUserDto UserToGetUserDto(this UserModel user) 
        {

            return new GetUserDto(user.Id, user.Name, user.Type, user.MaxBooks);

        }

        public static UserModel UserDtoToUserModel(this UserDto dto)
        {
            switch (dto.Type.ToLower())
            {
                case "student":
                    return new StudentModel(dto.Name);
                case "teacher":
                   
                    return new TeacherModel(dto.Name); 
                default:
                    throw new ArgumentException("Invalid user type.", nameof(dto.Type));
            }
        }

        public static UserModel PutUserDtoToUserModel(this PutUserDto dto)
        {
            switch (dto.Type.ToLower())
            {
                case "student":
                    return new StudentModel(dto.Id, dto.Name); // Agregar Id
                case "teacher":
                    return new TeacherModel(dto.Id, dto.Name); // Agregar Id
                default:
                    throw new ArgumentException("Invalid user type.", nameof(dto.Type));
            }
        }
    }
}