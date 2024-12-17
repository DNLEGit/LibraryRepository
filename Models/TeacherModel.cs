namespace LibraryApplication.Models
{
    public class TeacherModel : UserModel
    {
        public TeacherModel() : base("Teacher", string.Empty, 5) { }

        public TeacherModel(string name) : base("Teacher", name, 5) { }

        public TeacherModel(int id, string name) : base(id, "Teacher", name, 5) { }
    }
}