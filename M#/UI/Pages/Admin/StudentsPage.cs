using MSharp;

namespace Admin
{
    public class StudentsPage : SubPage<AdminPage>
    {
        public StudentsPage()
        {
            Add<Modules.StudentsList>();
        }
    }
}
