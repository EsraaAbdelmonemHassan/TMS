using MSharp;

namespace Admin.Course
{
    public class EnterPage : SubPage<CoursesPage>
    {
        public EnterPage()
        {
            Add<Modules.CourseForm>();
        }
    }
}
