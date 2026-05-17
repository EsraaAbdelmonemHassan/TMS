using MSharp;

namespace Admin.Student.StudentCourse
{
    public class EnterPage : SubPage<Admin.Student.EnterPage>
    {
        public EnterPage()
        {
            Layout(Layouts.AdminDefaultModal);
            Add<Modules.StudentCourseForm>();
        }
    }
}
