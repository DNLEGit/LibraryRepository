namespace LibraryApplication.Models
{
    public class StudentModel : UserModel
    {

        public StudentModel() : base("Student", string.Empty, 3) { }

        public StudentModel(string name) : base("Student", name, 3) { }

        public StudentModel(int id, string name) : base(id, "Student", name, 3) { }

    }
}
