using MSharp;

namespace Admin
{
    public class CoursesPage : SubPage<AdminPage>
    {
        public CoursesPage()
        {
            Add<Modules.CoursesList>();
        }
    }
}
