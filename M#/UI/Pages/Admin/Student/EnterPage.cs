using MSharp;

namespace Admin.Student
{
    public class EnterPage : SubPage<StudentsPage>
    {
        public EnterPage()
        {
            Add<Modules.StudentForm>();
            Add<Modules.StudentCoursesList>();
        }
    }
}
